using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// ImageToText recognition response
/// </summary>
public class ImageToTextResponse : CaptchaResponseBase
{
    /// <summary>
    /// Captcha answer
    /// </summary>
    [JsonPropertyName("text")]
    public string? Value { get; set; }
}
