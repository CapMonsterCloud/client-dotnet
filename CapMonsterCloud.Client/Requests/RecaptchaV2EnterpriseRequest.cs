using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// Recaptcha V2 Enterprise recognition request.
/// </summary>
public sealed class RecaptchaV2EnterpriseRequest : CaptchaRequestBaseWithProxy<RecaptchaV2EnterpriseResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "RecaptchaV2EnterpriseTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public override sealed string Type => TaskType;

    /// <summary>
    /// Address of a webpage with Google ReCaptcha
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// Recaptcha website key.
    /// <![CDATA[<div class="g-recaptcha" data-sitekey="THAT_ONE"></div>]]>
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// Additional parameters which should be passed to "grecaptcha.enterprise.render" method along with sitekey.
    /// Example of what you should search for:
    /// <![CDATA[
    /// grecaptcha.enterprise.render("some-div-id", {
    ///   sitekey: "6Lc_aCMTAAAAABx7u2N0D1XnVbI_v6ZdbM6rYf16",
    ///   theme: "dark",
    ///   s: "2JvUXHNTnZl1Jb6WEvbDyBMzrMTR7oQ78QRhBcG07rk9bpaAaE0LRq1ZeP5NYa0N...ugQA"
    ///   });
    /// ]]>
    /// In this example, you will notice a parameter "s" which is not documented, but obviously required.
    /// Send it to the API, so that we render the Recaptcha widget with this parameter properly.
    /// </summary>
    [JsonPropertyName("enterprisePayload")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string? EnterprisePayload { get; set; }

    /// <summary>
    /// Some custom implementations may contain additional "data-s" parameter in ReCaptcha2 div, which is in fact a one-time token and must be grabbed every time you want to solve a ReCaptcha2.
    /// <![CDATA[<div class="g-recaptcha" data-sitekey="some sitekey" data-s="THIS_ONE"></div>]]>
    /// </summary>
    [JsonPropertyName("recaptchaDataSValue")]
    public string? DataSValue { get; set; }

    /// <summary>
    /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
    /// https://zenno.link/doc-token-accept-en
    /// </summary>
    [JsonPropertyName("nocache")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NoCache { get; set; }

    internal override bool UseNoCache => this.NoCache ?? false;
}