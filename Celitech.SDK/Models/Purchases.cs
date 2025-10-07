using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Purchases(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("id")]
        string Id,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("startDate")]
        string StartDate,
    /// <value>End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("endDate")]
        string EndDate,
    /// <value>Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("createdDate")]
        string CreatedDate,
    [property: JsonPropertyName("package")] Package Package1,
    [property: JsonPropertyName("esim")] PurchasesEsim Esim,
    /// <value>The `source` indicates whether the purchase was made from the API, dashboard, landing-page, promo-page or iframe. For purchases made before September 8, 2023, the value will be displayed as 'Not available'.</value>
    [property: JsonPropertyName("source")]
        string Source,
    /// <value>The `purchaseType` indicates whether this is the initial purchase that creates the eSIM (First Purchase) or a subsequent top-up on an existing eSIM (Top-up Purchase).</value>
    [property: JsonPropertyName("purchaseType")]
        string PurchaseType,
    /// <value>Epoch value representing the start time of the package's validity</value>
    [property:
        JsonPropertyName("startTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? StartTime = null,
    /// <value>Epoch value representing the end time of the package's validity</value>
    [property:
        JsonPropertyName("endTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? EndTime = null,
    /// <value>Epoch value representing the date of creation of the purchase</value>
    [property:
        JsonPropertyName("createdAt"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? CreatedAt = null,
    /// <value>The `referenceId` that was provided by the partner during the purchase or top-up flow. This identifier can be used for analytics and debugging purposes.</value>
    [property: JsonPropertyName("referenceId")]
        string? ReferenceId = null
);
