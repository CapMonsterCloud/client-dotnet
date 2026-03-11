using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// Base captcha recognition request
/// </summary>
public abstract class CaptchaRequestBaseWithProxy<TResponse> : CaptchaRequestBase<TResponse>, IProxyInfo where TResponse : CaptchaResponseBase
{
    /// <inheritdoc/>
    [JsonIgnore]
    public ProxyContainer? Proxy
    {
        get
        {
            if (!string.IsNullOrEmpty(ProxyAddress))
                return new ProxyContainer(ProxyAddress, ProxyPort, ProxyType, ProxyLogin, ProxyPassword);

            return null;
        }
        set
        {
            if (value is not null)
            {
                ProxyAddress = value.ProxyAddress;
                ProxyPort = value.ProxyPort;
                ProxyType = value.ProxyType;
                ProxyLogin = value.ProxyLogin;
                ProxyPassword = value.ProxyPassword;
            }
        }
    }

    /// <inheritdoc/>
    [JsonPropertyName("proxyAddress")]
    [JsonInclude]
    internal string? ProxyAddress { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("proxyPort")]
    [JsonInclude]
    [Range(0, 65535)]
    protected internal int ProxyPort { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("proxyType")]
    [JsonInclude]
    [JsonConverter(typeof(Json.CamelCaseStringEnumConverter))]
    internal ProxyType ProxyType { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("proxyLogin")]
    [JsonInclude]
    internal string? ProxyLogin { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("proxyPassword")]
    [JsonInclude]
    internal string? ProxyPassword { get; set; }
}
