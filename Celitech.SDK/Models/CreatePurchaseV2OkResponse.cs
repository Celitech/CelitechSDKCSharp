using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseV2OkResponse(
    [property: JsonPropertyName("purchase")] CreatePurchaseV2OkResponsePurchase Purchase,
    [property: JsonPropertyName("profile")] CreatePurchaseV2OkResponseProfile Profile
);
