using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimHistoryOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid,
    [property: JsonPropertyName("history")] List<History> History1
);
