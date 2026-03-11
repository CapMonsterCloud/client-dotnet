using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud;

public partial class CapMonsterCloudClient
{
    private class ResponseBase
    {
        [JsonPropertyName("errorId")]
        public int ErrorId { get; set; }

        [JsonPropertyName("errorCode")]
        public string? ErrorCode { get; set; }
    }

    private class GetBalanceResponse : ResponseBase
    {
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }

    private class CreateTaskResponse : ResponseBase
    {
        [JsonPropertyName("taskId")]
        public int TaskId { get; set; }
    }

    private class GetTaskResultResponse : ResponseBase
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("solution")]
        public object? Solution { get; set; }
    }

    private abstract class TaskResult
    {
        public class TaskInProgress : TaskResult;

        public class TaskFailed(ErrorType error) : TaskResult
        {
            public ErrorType Error { get; } = error;
        }

        public class TaskCompleted(object? solution) : TaskResult
        {
            public object? Solution { get; } = solution;
        }

        public static TaskInProgress InProgress { get; } = new();

        public static TaskFailed Failed(ErrorType error) => new(error);

        public static TaskCompleted Completed(object? solution) => new(solution);
    }

    private class CreateTaskRequest<TSolution> where TSolution : CaptchaResponseBase
    {
        [JsonPropertyName("clientKey")]
        public string? ClientKey { get; set; }

        [JsonPropertyName("task")]
        public Requests.CaptchaRequestBase<TSolution>? Task { get; set; }

        [JsonPropertyName("softId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SoftId { get; set; }
    }
}
