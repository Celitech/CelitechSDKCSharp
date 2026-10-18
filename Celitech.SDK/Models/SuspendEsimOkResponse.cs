using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record SuspendEsimOkResponse(
    /// <value>Confirmation message</value>
    [property: JsonPropertyName("message")] string Message
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
