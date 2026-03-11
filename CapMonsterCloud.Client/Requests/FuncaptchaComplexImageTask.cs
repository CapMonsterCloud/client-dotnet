using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// ComplexImageTask recognition request for funcaptcha images
/// </summary>
public sealed class FunCaptchaComplexImageTaskRequest : ComplexImageTaskRequestBase<GridComplexImageTaskResponse>
{
    /// <summary>
    /// Metadata for recognition
    /// </summary>
    public sealed class FunCaptchaMetadata
    {
        /// <summary>
        /// Task text(in english). Required.
        /// </summary>
        /// <example>
        /// Pick the image that is the correct way up
        /// </example>
        [Required]
        [JsonPropertyName("Task")]
        public string Task { get; set; } = null!;
    }

    /// <inheritdoc/>
    public override string Class => "funcaptcha";

    /// <summary>
    /// Metadata for recognition
    /// </summary>
    [JsonPropertyName("metadata")]
    [Required]
    public FunCaptchaMetadata Metadata { get; set; } = null!;
}
