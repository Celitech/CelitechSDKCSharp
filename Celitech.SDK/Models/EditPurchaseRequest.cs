using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record EditPurchaseRequest(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("purchaseId")]
        string PurchaseId,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</value>
    [property: JsonPropertyName("startDate")]
        string StartDate,
    /// <value>End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</value>
    [property: JsonPropertyName("endDate")]
        string EndDate,
    /// <value>Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months.</value>
    [property:
        JsonPropertyName("startTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? StartTime = null,
    /// <value>Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time.</value>
    [property:
        JsonPropertyName("endTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? EndTime = null
);
