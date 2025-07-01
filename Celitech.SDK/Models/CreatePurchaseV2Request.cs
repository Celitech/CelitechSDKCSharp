using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseV2Request(
    /// <value>ISO representation of the package's destination.</value>
    [property: JsonPropertyName("destination")]
        string Destination,
    /// <value>Size of the package in GB. The available options are 0.5, 1, 2, 3, 5, 8, 20GB</value>
    [property: JsonPropertyName("dataLimitInGB")]
        double DataLimitInGb,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</value>
    [property: JsonPropertyName("startDate")]
        string StartDate,
    /// <value>End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</value>
    [property: JsonPropertyName("endDate")]
        string EndDate,
    /// <value>Number of eSIMs to purchase.</value>
    [property: JsonPropertyName("quantity")]
        double Quantity,
    /// <value>Email address where the purchase confirmation email will be sent (including QR Code & activation steps)</value>
    [property:
        JsonPropertyName("email"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Email = null,
    /// <value>An identifier provided by the partner to link this purchase to their booking or transaction for analytics and debugging purposes.</value>
    [property:
        JsonPropertyName("referenceId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ReferenceId = null,
    /// <value>Customize the network brand of the issued eSIM. The `networkBrand` parameter cannot exceed 15 characters in length and must contain only letters and numbers. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("networkBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? NetworkBrand = null,
    /// <value>Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("emailBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? EmailBrand = null
);
