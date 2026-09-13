using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimOkResponse([property: JsonPropertyName("esim")] GetEsimOkResponseEsim Esim)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
