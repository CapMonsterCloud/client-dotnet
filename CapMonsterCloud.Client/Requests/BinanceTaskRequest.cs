using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// BinanceTask recognition request.
/// </summary>
/// <example>
/// https://docs.capmonster.cloud/docs/captchas/binance
/// </example>
public sealed class BinanceTaskRequest : CaptchaRequestBaseWithProxy<BinanceTaskResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "BinanceTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public override sealed string Type => TaskType;

    /// <summary>
    /// The address of the main page where the captcha is solved.
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// A unique parameter for your website's section. The value of the parameter bizId, bizType, or bizCode. It can be taken from the traffic
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// A dynamic key. The value of the parameter validateId, securityId, or securityCheckResponseValidateId. It can be taken from the traffic.
    /// </summary>
    [JsonPropertyName("validateId")]
    public string ValidateId { get; set; } = null!;

    /// <summary>
    /// Browser's User-Agent which is used in emulation.
    /// </summary>
    /// <remarks>
    /// It is required that you use a signature of a modern browser,
    /// otherwise Google will ask you to "update your browser".
    /// </remarks>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
