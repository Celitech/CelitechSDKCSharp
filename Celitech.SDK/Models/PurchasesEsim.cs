using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record PurchasesEsim(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid
);
