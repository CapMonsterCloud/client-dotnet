using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// ComplexImageTask recognition request
/// </summary>
public abstract class ComplexImageTaskRequestBase<TResponse> : CaptchaRequestBase<TResponse> where TResponse : CaptchaResponseBase
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "ComplexImageTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public sealed override string Type => TaskType;

    /// <summary>
    /// Class(subtype) of ComplexImageTask
    /// </summary>
    [JsonPropertyName("class")]
    public abstract string Class { get; }

    /// <summary>
    /// Collection with image urls. Must be populated if <see cref="ImagesBase64"/> not.
    /// </summary>
    [JsonPropertyName("imageUrls")]
    public ICollection<string>? ImageUrls { get; set; }

    /// <summary>
    /// Collection with base64 encoded images. Must be populated if <see cref="ImageUrls"/> not.
    /// </summary>
    [JsonPropertyName("imagesBase64")]
    public ICollection<string>? ImagesBase64 { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation.
    /// </summary>
    /// <remarks>
    /// It is required that you use a signature of a modern browser
    /// </remarks>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Address of a webpage with captcha
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;
}
