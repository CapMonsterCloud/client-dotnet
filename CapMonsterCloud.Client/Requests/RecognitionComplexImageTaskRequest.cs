using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests;

/// <summary>
/// ComplexImageTask recognition request for Recognition images
/// </summary>
public sealed class RecognitionComplexImageTaskRequest : ComplexImageTaskRequestBase<DynamicComplexImageTaskResponse>
{
    /// <inheritdoc/>
    public override string Class => "recognition";

    /// <summary>
    /// Metadata for recognition
    /// </summary>
    public sealed class RecognitionMetadata
    {
        /// <summary>
        /// Task definition. Required.
        /// </summary>
        /// <example>
        /// oocl_rotate_new
        /// </example>
        [Required]
        [JsonPropertyName("Task")]
        public string Task { get; set; } = null!;

        /// <summary>
        /// Additional task argument definition. Optional.
        /// </summary>
        /// <example>
        /// 546
        /// </example>
        [JsonPropertyName("TaskArgument")]
        public string? TaskArgument { get; set; }
    }

    /// <summary>
    /// Metadata for recognition
    /// </summary>
    [JsonPropertyName("metadata")]
    [Required]
    public RecognitionMetadata Metadata { get; set; } = null!;
}
