using System.Text.Json.Serialization;

namespace Celitech.Models;

public record TopUpEsimOkResponse(
    [property: JsonPropertyName("purchase")] TopUpEsimOkResponsePurchase Purchase,
    [property: JsonPropertyName("profile")] TopUpEsimOkResponseProfile Profile
);
