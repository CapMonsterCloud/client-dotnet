using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// MTCaptcha recognition response
/// </summary>
public sealed class MTCaptchaTaskResponse : CaptchaResponseBase
{
    /// <summary>
    /// MTCaptcha token to submit to the target site.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Value { get; set; }
}