using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// reCAPTCHA v3 Enterprise recognition request.
/// The task is executed through CapMonster Cloud's own proxy servers (no user proxy needed).
/// </summary>
/// <example>
/// https://docs.capmonster.cloud/docs/captchas/recaptcha-v3-enterprise-task/
/// </example>
public sealed class RecaptchaV3EnterpriseRequest : CaptchaRequestBase<RecaptchaV3EnterpriseResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "RecaptchaV3EnterpriseTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public override string Type => TaskType;

    /// <summary>
    /// Address of a webpage with Google reCAPTCHA Enterprise.
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// The reCAPTCHA v3 Enterprise site key on the target page.
    /// <![CDATA[https://www.google.com/recaptcha/enterprise.js?render=THIS_ONE]]>
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// Value from 0.1 to 0.9.
    /// </summary>
    [JsonPropertyName("minScore")]
    [Range(0.1, 0.9)]
    public double MinScore { get; set; }

    /// <summary>
    /// The action parameter value passed by the reCAPTCHA widget to Google,
    /// which is visible to the site owner during server-side verification.
    /// Default value: verify
    /// </summary>
    /// <example>
    /// <![CDATA[grecaptcha.enterprise.execute('site_key', {action:'login_test'})]]>
    /// </example>
    [JsonPropertyName("pageAction")]
    public string PageAction { get; set; } = "verify";

    /// <summary>
    /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
    /// https://zenno.link/doc-token-accept-en
    /// </summary>
    [JsonPropertyName("nocache")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NoCache { get; set; }

    internal override bool UseNoCache => this.NoCache ?? false;
}
