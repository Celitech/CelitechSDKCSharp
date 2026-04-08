using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimHistoryOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")] string Iccid,
    [property: JsonPropertyName("history")] List<History> History
);
