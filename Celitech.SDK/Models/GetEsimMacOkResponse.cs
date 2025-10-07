using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimMacOkResponse(
    [property: JsonPropertyName("esim")] GetEsimMacOkResponseEsim Esim
);
