using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Json;

internal class RecognitionAnswerJsonConverter : JsonConverter<DynamicComplexImageTaskResponse>
{
    public override DynamicComplexImageTaskResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("metadata", out var metadataEl) ||
            !root.TryGetProperty("answer", out var answerEl))
            throw new JsonException("Missing 'metadata' or 'answer' field in response");

        var answerType = metadataEl.TryGetProperty("AnswerType", out var atEl)
            ? atEl.GetString()
            : null;

        if (string.IsNullOrEmpty(answerType))
            throw new JsonException("AnswerType is missing in metadata");

        var response = new DynamicComplexImageTaskResponse
        {
            Metadata = new DynamicComplexImageTaskResponse.RecognitionMetadata
            {
                AnswerType = answerType
            },
            Answer = answerType switch
            {
                "NumericArray" => new RecognitionAnswer
                {
                    NumericAnswer = JsonSerializer.Deserialize<decimal[]>(answerEl.GetRawText(), options)
                },
                "Grid" => new RecognitionAnswer
                {
                    GridAnswer = JsonSerializer.Deserialize<bool[]>(answerEl.GetRawText(), options)
                },
                _ => throw new JsonException($"Unknown AnswerType: {answerType}")
            }
        };

        return response;
    }

    public override void Write(Utf8JsonWriter writer, DynamicComplexImageTaskResponse value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("answer");

        if (value.Metadata?.AnswerType == "Grid" && value.Answer?.GridAnswer is not null)
        {
            JsonSerializer.Serialize(writer, value.Answer.GridAnswer, options);
        }
        else if (value.Metadata?.AnswerType == "NumericArray" && value.Answer?.NumericAnswer is not null)
        {
            JsonSerializer.Serialize(writer, value.Answer.NumericAnswer, options);
        }
        else
        {
            throw new JsonException("Invalid or missing answer data for the specified AnswerType.");
        }

        writer.WritePropertyName("metadata");
        JsonSerializer.Serialize(writer, value.Metadata, options);

        writer.WriteEndObject();
    }
}
