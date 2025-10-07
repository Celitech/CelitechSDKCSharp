using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimHistoryOkResponse(
    [property: JsonPropertyName("esim")] GetEsimHistoryOkResponseEsim Esim
);
