using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseV2OkResponse(
    [property:
        JsonPropertyName("purchase"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        CreatePurchaseV2OkResponsePurchase? Purchase = null,
    [property:
        JsonPropertyName("profile"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        CreatePurchaseV2OkResponseProfile? Profile = null
);
