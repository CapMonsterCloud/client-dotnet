using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Json;
using static Zennolab.CapMonsterCloud.Requests.RecognitionComplexImageTaskRequest;

namespace Zennolab.CapMonsterCloud.Responses;

/// <summary>
/// Response for Recognition grid-like tasks
/// </summary>
[JsonConverter(typeof(RecognitionAnswerJsonConverter))]
public class DynamicComplexImageTaskResponse : CaptchaResponseBase
{
    /// <summary>
    /// Metadata class containing AnswerType
    /// </summary>
    public class RecognitionMetadata
    {
        [JsonPropertyName("AnswerType")]
        public string? AnswerType { get; set; }
    }

    /// <summary>
    /// Bool or decimal collection with answers
    /// </summary>
    /// <example>
    /// [false,true,false,true,false,false,true,false,false]
    /// [4,4,4,4,4,3,1,2,2]
    /// [130.90909]
    /// </example>
    [JsonPropertyName("answer")]
    public RecognitionAnswer? Answer { get; set; }

    /// <summary>
    /// Metadata containing the answer type
    /// </summary>
    [JsonPropertyName("metadata")]
    public RecognitionMetadata? Metadata { get; set; }
}
