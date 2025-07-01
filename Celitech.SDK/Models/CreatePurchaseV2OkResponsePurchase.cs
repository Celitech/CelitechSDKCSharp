using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseV2OkResponsePurchase(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>ID of the package</value>
    [property:
        JsonPropertyName("packageId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? PackageId = null,
    /// <value>Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property:
        JsonPropertyName("createdDate"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CreatedDate = null
);
