using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zennolab.CapMonsterCloud.Json;

internal sealed class CamelCaseStringEnumConverter() : JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
