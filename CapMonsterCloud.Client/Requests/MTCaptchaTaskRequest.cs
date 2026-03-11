using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// MTCaptcha recognition request.
/// </summary>
/// <example>
/// https://docs.capmonster.cloud/docs/captchas/mtcaptcha-task/
/// </example>
public sealed class MTCaptchaTaskRequest : CaptchaRequestBaseWithProxy<MTCaptchaTaskResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "MTCaptchaTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public sealed override string Type => TaskType;

    /// <summary>
    /// Address of a web page with MTCaptcha.
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// The MTCaptcha key (sk/sitekey).
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// true for invisible widget (has hidden confirmation field).
    /// </summary>
    [JsonPropertyName("isInvisible")]
    public bool Invisible { get; set; }

    /// <summary>
    /// Action value (passed as "act" and shown during token validation).
    /// Provide only if it differs from default "%24".
    /// </summary>
    [JsonPropertyName("pageAction")]
    public string? PageAction { get; set; }

    /// <summary>
    /// Browser's User-Agent (actual Windows UA recommended).
    /// </summary>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}