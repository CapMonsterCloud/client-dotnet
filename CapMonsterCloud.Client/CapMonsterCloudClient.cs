using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;
using Zennolab.CapMonsterCloud.Validation;

namespace Zennolab.CapMonsterCloud;

/// <summary>
/// capmonster.cloud Client
/// </summary>
public partial class CapMonsterCloudClient(ClientOptions options, HttpClient httpClient) : ICapMonsterCloudClient
{
    private const string TaskReady = "ready";

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    internal HttpClient HttpClient { get; } = httpClient;

    /// <inheritdoc/>
    /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
    public async Task<decimal> GetBalanceAsync(CancellationToken cancellationToken)
    {
        var response = await HttpClient.PostAsync(
            "getBalance",
            new StringContent(ToJson(
                new { clientKey = options.ClientKey })),
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Cannot get balance. Status code was {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        var result = FromJson<GetBalanceResponse>(responseBody)
            ?? throw new HttpRequestException($"Cannot parse get balance response. Response was: {responseBody}");

        if (result.ErrorId != 0)
        {
            throw new GetBalanceException(ToErrorType(result.ErrorCode));
        }

        return result.Balance;
    }

    /// <inheritdoc/>
    /// <exception cref="ValidationException">malformed task object</exception>
    /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
    public async Task<CaptchaResult<TSolution>> SolveAsync<TSolution>(
        CaptchaRequestBase<TSolution> task,
        CancellationToken cancellationToken) where TSolution : CaptchaResponseBase
    {
        ValidateTask<CaptchaRequestBase<TSolution>, TSolution>(task);

        var createdTask = await CreateTask(task, cancellationToken);
        if (createdTask.ErrorId != 0)
        {
            return new CaptchaResult<TSolution> { Error = ToErrorType(createdTask.ErrorCode) };
        }

        var getResultTimeouts = GetTimeouts(task.GetType());

        using var getResultTimeoutCts = new CancellationTokenSource(getResultTimeouts.Timeout);
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, getResultTimeoutCts.Token);

        var firstRequestDelay = (task.UseNoCache ? getResultTimeouts.FirstRequestNoCacheDelay : null)
            ?? getResultTimeouts.FirstRequestDelay;
        await Task.Delay(firstRequestDelay, linkedCts.Token);

        while (!linkedCts.IsCancellationRequested)
        {
            try
            {
                var result = await GetTaskResult(createdTask.TaskId, linkedCts.Token);

                switch (result)
                {
                    case TaskResult.TaskFailed failed:
                        return new CaptchaResult<TSolution> { Error = failed.Error };
                    case TaskResult.TaskCompleted completed:
                        return new CaptchaResult<TSolution> { Solution = CastSolution<TSolution>(completed.Solution) };
                }
            }
            catch (OperationCanceledException)
            {
                if (getResultTimeoutCts.IsCancellationRequested)
                {
                    break;
                }

                throw;
            }

            await Task.Delay(getResultTimeouts.RequestsInterval, linkedCts.Token);
        }

        return new CaptchaResult<TSolution> { Error = ErrorType.Timeout };
    }

    private static void ValidateTask<TTask, TSolution>(TTask task) where TTask : CaptchaRequestBase<TSolution> where TSolution : CaptchaResponseBase
        => TaskValidator.ValidateObjectIncludingInternals(task);

    private async Task<CreateTaskResponse> CreateTask<TSolution>(CaptchaRequestBase<TSolution> task, CancellationToken cancellationToken) where TSolution : CaptchaResponseBase
    {
        var body = ToJson(
            new CreateTaskRequest<TSolution>
            {
                ClientKey = options.ClientKey,
                Task = task,
                SoftId = options.SoftId ?? ClientOptions.DefaultSoftId
            });

        var response = await HttpClient.PostAsync("createTask", new StringContent(body), cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Cannot create task. Status code was {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        return FromJson<CreateTaskResponse>(responseBody)
            ?? throw new HttpRequestException($"Cannot parse create task response. Response was: {responseBody}");
    }

    private async Task<TaskResult> GetTaskResult(int taskId, CancellationToken cancellationToken)
    {
        var body = ToJson(
            new
            {
                clientKey = options.ClientKey,
                taskId
            });

        var response = await HttpClient.PostAsync("getTaskResult", new StringContent(body), cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
        {
            return TaskResult.InProgress;
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Cannot get task result. Status code was {response.StatusCode}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        var result = FromJson<GetTaskResultResponse>(responseBody)
            ?? throw new HttpRequestException($"Cannot parse get task result response. Response was: {responseBody}");

        if (result.ErrorId != 0)
        {
            return "CAPTCHA_NOT_READY".Equals(result.ErrorCode, StringComparison.OrdinalIgnoreCase)
                ? TaskResult.InProgress
                : TaskResult.Failed(ToErrorType(result.ErrorCode));
        }

        if (TaskReady.Equals(result.Status, StringComparison.OrdinalIgnoreCase))
        {
            return TaskResult.Completed(result.Solution);
        }

        return TaskResult.InProgress;
    }

    private static TSolution CastSolution<TSolution>(object? solution)
    {
        var json = solution is JsonElement element
            ? element.GetRawText()
            : solution?.ToString() ?? "{}";

        return FromJson<TSolution>(json)
            ?? throw new JsonException($"Cannot deserialize solution to {typeof(TSolution).Name}");
    }

    private static ErrorType ToErrorType(string? errorCode)
        => ErrorCodeConverter.Convert(errorCode);

    internal static string ToJson(object data)
        => JsonSerializer.Serialize(data, data.GetType(), SerializerOptions);

    internal static TOut? FromJson<TOut>(string json)
        => JsonSerializer.Deserialize<TOut>(json, SerializerOptions);
}
