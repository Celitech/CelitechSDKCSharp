using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimDeviceOkResponse([property: JsonPropertyName("device")] Device Device)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
