using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Zennolab.CapMonsterCloud.Json;

internal sealed class DictionaryToSemicolonSplittedStringConverter : JsonConverter<IDictionary<string, string>>
{
    public override IDictionary<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException("Expected a string token for semicolon-separated dictionary");

        var value = reader.GetString();
        var regexValidation = new Regex("^((.*)(=?){2};?)+$");

        if (value is not null && regexValidation.IsMatch(value))
            try
            {
                return value.Split(';').Select(item =>
                {
                    var keyValueItem = item.Split('=');
                    return new KeyValuePair<string, string>(keyValueItem[0], keyValueItem[1]);
                }).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception) { }

        throw new JsonException("Invalid semicolon-separated dictionary format");
    }

    public override void Write(Utf8JsonWriter writer, IDictionary<string, string> value, JsonSerializerOptions options)
    {
        var result = string.Join(";", value.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        writer.WriteStringValue(result);
    }
}
