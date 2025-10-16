using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseV2OkResponsePurchase(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("id")]
        string Id,
    /// <value>ID of the package</value>
    [property: JsonPropertyName("packageId")]
        string PackageId,
    /// <value>Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("createdDate")]
        string CreatedDate
);
