using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// AmazonWaf recognition response
/// </summary>
public sealed class AmazonWafResponse : CaptchaResponseBase
{
    /// <inheritdoc/>
    [JsonPropertyName("captcha_voucher")]
    public string? CaptchaVoucher { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("existing_token")]
    public string? ExistingToken { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("cookies")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Cookies { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("userAgent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserAgent { get; set; }
}
