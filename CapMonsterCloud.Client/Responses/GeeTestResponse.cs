using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// GeeTest recognition response
/// </summary>
public class GeeTestResponse : CaptchaResponseBase
{
    /// <summary>
    /// </summary>
    /// <example>0f759dd1ea6c4wc76cedc2991039ca4f23</example>
    [JsonPropertyName("challenge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Challenge { get; set; }

    /// <summary>
    /// </summary>
    /// <example>6275e26419211d1f526e674d97110e15</example>
    [JsonPropertyName("validate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Validate { get; set; }

    /// <summary>
    /// </summary>
    /// <example>510cd9735583edcb158601067195a5eb|jordan</example>
    [JsonPropertyName("seccode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SecCode { get; set; }
    
    /// <summary>
    /// </summary>
    /// <example>f5c2ad5a8a3cf37192d8b9c039950f79</example>
    [JsonPropertyName("captcha_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CaptchaId { get; set; }

    /// <summary>
    /// </summary>
    /// <example>bcb2c6ce2f8e4e9da74f2c1fa63bd713</example>
    [JsonPropertyName("lot_number")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LotNumber { get; set; }

    /// <summary>
    /// </summary>
    /// <example>edc7a17716535a5ae624ef4707cb6e7e478dc557608b068d202682c8297695cf</example>
    [JsonPropertyName("pass_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PassToken { get; set; }
    
    /// <summary>
    /// </summary>
    /// <example>1683794919</example>
    [JsonPropertyName("gen_time")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GenTime { get; set; }
    
    /// <summary>
    /// </summary>
    /// <example>XwmTZEJCJEnRIJBlvtEAZ662T...[cut]...SQ3fX-MyoYOVDMDXWSRQig56</example>
    [JsonPropertyName("captcha_output")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CaptchaOutput { get; set; }
}
