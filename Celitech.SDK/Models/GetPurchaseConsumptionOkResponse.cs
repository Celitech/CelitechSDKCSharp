using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetPurchaseConsumptionOkResponse(
    /// <value>Remaining balance of the package in bytes</value>
    [property: JsonPropertyName("dataUsageRemainingInBytes")]
        double DataUsageRemainingInBytes,
    /// <value>Status of the connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'</value>
    [property: JsonPropertyName("status")]
        string Status
);
