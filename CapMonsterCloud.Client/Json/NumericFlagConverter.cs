using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Json;

internal sealed class NumericFlagConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.Number => reader.GetInt32() != 0,
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            _ => throw new JsonException($"Unexpected token type {reader.TokenType} for bool")
        };

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value ? 1 : 0);
}
