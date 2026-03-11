using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// Yidun (NECaptcha) recognition request.
/// </summary>
/// <example>
/// https://docs.capmonster.cloud/docs/captchas/yidun-task
/// </example>
public sealed class YidunTaskRequest : CaptchaRequestBaseWithProxy<YidunTaskResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "YidunTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public override sealed string Type => TaskType;

    /// <summary>
    /// Full URL of the page with the captcha.
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// The siteKey value found on the page.
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// Browser User-Agent (actual Windows UA recommended).
    /// </summary>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Full URL of JS loader (Enterprise cases).
    /// </summary>
    [JsonPropertyName("yidunGetLib")]
    public string? YidunGetLib { get; set; }

    /// <summary>
    /// Custom API server subdomain (Enterprise cases).
    /// </summary>
    [JsonPropertyName("yidunApiServerSubdomain")]
    public string? YidunApiServerSubdomain { get; set; }

    /// <summary>
    /// Enterprise: current captcha challenge id.
    /// </summary>
    [JsonPropertyName("challenge")]
    public string? Challenge { get; set; }

    /// <summary>
    /// Enterprise: captcha hash.
    /// </summary>
    [JsonPropertyName("hcg")]
    public string? Hcg { get; set; }

    /// <summary>
    /// Enterprise: numeric timestamp.
    /// </summary>
    [JsonPropertyName("hct")]
    public long? Hct { get; set; }
}
