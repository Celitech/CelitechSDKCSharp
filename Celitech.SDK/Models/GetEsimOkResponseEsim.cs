using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid,
    /// <value>SM-DP+ Address</value>
    [property: JsonPropertyName("smdpAddress")]
        string SmdpAddress,
    /// <value>QR Code of the eSIM as base64</value>
    [property: JsonPropertyName("activationCode")]
        string ActivationCode,
    /// <value>The manual activation code</value>
    [property: JsonPropertyName("manualActivationCode")]
        string ManualActivationCode,
    /// <value>Status of the eSIM, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR'</value>
    [property: JsonPropertyName("status")]
        string Status,
    /// <value>Indicates whether the eSIM is currently eligible for a top-up. This flag should be checked before attempting a top-up request.</value>
    [property: JsonPropertyName("isTopUpAllowed")]
        bool IsTopUpAllowed
);
