using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseOkResponse(
    [property:
        JsonPropertyName("purchase"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        CreatePurchaseOkResponsePurchase? Purchase = null,
    [property:
        JsonPropertyName("profile"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        CreatePurchaseOkResponseProfile? Profile = null
);
