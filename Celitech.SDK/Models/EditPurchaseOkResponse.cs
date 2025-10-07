using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record EditPurchaseOkResponse(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("purchaseId")]
        string PurchaseId,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("newStartDate")]
        string NewStartDate,
    /// <value>End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("newEndDate")]
        string NewEndDate,
    /// <value>Epoch value representing the new start time of the package's validity</value>
    [property:
        JsonPropertyName("newStartTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? NewStartTime = null,
    /// <value>Epoch value representing the new end time of the package's validity</value>
    [property:
        JsonPropertyName("newEndTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? NewEndTime = null
);
