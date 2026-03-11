using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// CustomTask recognition request
/// </summary>
public abstract class CustomTaskRequestBase : CaptchaRequestBaseWithProxy<CustomTaskResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "CustomTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public sealed override string Type => TaskType;

    /// <summary>
    /// Class (subtype) of CustomTask
    /// </summary>
    [JsonPropertyName("class")]
    public abstract string Class { get; }

    /// <summary>
    /// Address of the main page where the captcha is solved
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = string.Empty;

    /// <summary>
    /// The object that contains additional data about the captcha - captchaUrl: "captchaUrl": "..."
    /// You can take the link from the page with the captcha.
    /// Often it looks like https://geo.captcha-delivery.com/captcha/?initialCid=...
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Metadata { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation.
    /// </summary>
    /// <remarks>
    /// Pass only the actual User-Agent from Windows OS.
    /// </remarks>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// For the specified domains the corresponding cookies will be returned in the response.
    /// </summary>
    [JsonPropertyName("domains")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string>? Domains { get; set; }
}
