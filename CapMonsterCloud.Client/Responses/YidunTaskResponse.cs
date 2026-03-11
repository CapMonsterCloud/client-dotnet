using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// Yidun (NECaptcha) recognition response
/// </summary>
public sealed class YidunTaskResponse : CaptchaResponseBase
{
    /// <summary>
    /// Yidun token to submit.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Value { get; set; }
}