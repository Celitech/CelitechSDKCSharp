using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TopUpEsimOkResponse(
    [property: JsonPropertyName("purchase")] TopUpEsimOkResponsePurchase Purchase,
    [property: JsonPropertyName("profile")] TopUpEsimOkResponseProfile Profile
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
