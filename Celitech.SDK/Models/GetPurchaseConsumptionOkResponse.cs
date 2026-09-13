using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetPurchaseConsumptionOkResponse(
    /// <value>Remaining balance of the package in bytes. Returns `-1` for unlimited packages.</value>
    [property: JsonPropertyName("dataUsageRemainingInBytes")] double DataUsageRemainingInBytes,
    /// <value>Remaining balance of the package in GB. Returns `-1` for unlimited packages.</value>
    [property: JsonPropertyName("dataUsageRemainingInGB")] double DataUsageRemainingInGb,
    /// <value>Status of the connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'</value>
    [property: JsonPropertyName("status")] string Status
)
{
    [JsonExtensionData]
    public Dictionary<string, object?> AdditionalProperties { get; set; } = new();
}
