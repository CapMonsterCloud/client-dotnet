using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// AmazonWaf recognition request.
/// </summary>
/// <example>
/// https://docs.capmonster.cloud/docs/captchas/amazon-task
/// </example>
public class AmazonWafRequest : CaptchaRequestBaseWithProxy<AmazonWafResponse>
{
    /// <summary>
    /// Recognition task type
    /// </summary>
    public const string TaskType = "AmazonTask";

    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public override sealed string Type => TaskType;

    /// <summary>
    /// The address of the main page where captcha is solved.
    /// </summary>
    [JsonPropertyName("websiteURL")]
    [Url]
    public string WebsiteUrl { get; set; } = null!;

    /// <summary>
    /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.key
    /// </summary>
    [JsonPropertyName("websiteKey")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string WebsiteKey { get; set; } = null!;

    /// <summary>
    /// Link to challenge.js (see description below the table)
    /// </summary>
    [JsonPropertyName("challengeScript")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string ChallengeScript { get; set; } = null!;

    /// <summary>
    /// Link to captcha.js (see description below the table)
    /// </summary>
    [JsonPropertyName("captchaScript")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string CaptchaScript { get; set; } = null!;

    /// <summary>
    /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.context
    /// </summary>
    [JsonPropertyName("context")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string Context { get; set; } = null!;

    /// <summary>
    /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.iv
    /// </summary>
    [JsonPropertyName("iv")]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string Iv { get; set; } = null!;

    /// <summary>
    /// By default false. If you need to use cookies "aws-waf-token", specify the value true. Otherwise, what you will get in return is "captcha_voucher" and "existing_token".
    /// </summary>
    [JsonPropertyName("cookieSolution")]
    public bool CookieSolution { get; set; }
}
