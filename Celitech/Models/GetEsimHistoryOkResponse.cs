using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimHistoryOkResponse(
    [property: JsonPropertyName("esim")] GetEsimHistoryOkResponseEsim Esim
);
