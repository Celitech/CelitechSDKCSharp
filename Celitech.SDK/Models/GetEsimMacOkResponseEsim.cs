using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimMacOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid,
    /// <value>SM-DP+ Address</value>
    [property: JsonPropertyName("smdpAddress")]
        string SmdpAddress,
    /// <value>The manual activation code</value>
    [property: JsonPropertyName("manualActivationCode")]
        string ManualActivationCode
);
