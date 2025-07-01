using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetPurchaseConsumptionOkResponse(
    /// <value>Remaining balance of the package in bytes</value>
    [property:
        JsonPropertyName("dataUsageRemainingInBytes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DataUsageRemainingInBytes = null,
    /// <value>Status of the connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'</value>
    [property:
        JsonPropertyName("status"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Status = null
);
