using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseOkResponseProfile(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid,
    /// <value>QR Code of the eSIM as base64</value>
    [property: JsonPropertyName("activationCode")]
        string ActivationCode,
    /// <value>Manual Activation Code of the eSIM</value>
    [property: JsonPropertyName("manualActivationCode")]
        string ManualActivationCode
);
