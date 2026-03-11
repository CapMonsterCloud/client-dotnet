using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// Response for custom tasks
/// </summary>
public class CustomTaskResponse : CaptchaResponseBase
{
    /// <inheritdoc/>
    public sealed class DomainInfo
    {
        /// <inheritdoc/>
        [JsonPropertyName("cookies")]
        public Dictionary<string, string>? Cookies { get; set; }

        /// <inheritdoc/>
        [JsonPropertyName("localStorage")]
        public Dictionary<string, string>? LocalStorage { get; set; }
    }

    /// <inheritdoc/>
    [JsonPropertyName("domains")]
    public Dictionary<string, DomainInfo>? Domains { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("fingerprint")]
    public Dictionary<string, string>? Fingerprint { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("data")]
    public Dictionary<string, string>? Data;
}
