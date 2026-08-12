using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TokenOkResponse(
    /// <value>The generated token</value>
    [property: JsonPropertyName("token")] string Token
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
