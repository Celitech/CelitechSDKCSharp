using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Unauthorized(
    /// <value>Message of the error</value>
    [property:
        JsonPropertyName("message"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ] string? Message = null
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
