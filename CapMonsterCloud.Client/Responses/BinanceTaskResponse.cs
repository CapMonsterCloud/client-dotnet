using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// BinanceTask recognition response
/// </summary>
public sealed class BinanceTaskResponse : CaptchaResponseBase
{
    /// <summary>
    /// BinanceTask token
    /// </summary>
    /// <example>
    /// captcha#09ba4905a79f44f2a99e44f234439644-ioVA7neog7eRHCDAsC0MixpZvt5kc99maS943qIsquNP9D77
    /// </example>
    [JsonPropertyName("token")]
    public string? Value { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("userAgent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserAgent { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("cookies")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Cookies { get; set; }
}
