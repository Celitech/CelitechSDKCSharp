using System.Text.Json.Serialization;

namespace Celitech.Models;

public record CreatePurchaseOkResponse(
    [property: JsonPropertyName("purchase")] CreatePurchaseOkResponsePurchase Purchase,
    [property: JsonPropertyName("profile")] CreatePurchaseOkResponseProfile Profile
);
