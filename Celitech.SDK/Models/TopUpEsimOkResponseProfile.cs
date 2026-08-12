using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TopUpEsimOkResponseProfile(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")] string Iccid
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
