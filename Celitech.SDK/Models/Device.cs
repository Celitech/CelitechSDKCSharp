using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Device(
    /// <value>Name of the OEM</value>
    [property: JsonPropertyName("oem")]
        string Oem,
    /// <value>Name of the Device</value>
    [property: JsonPropertyName("hardwareName")]
        string HardwareName,
    /// <value>Model of the Device</value>
    [property: JsonPropertyName("hardwareModel")]
        string HardwareModel,
    /// <value>Serial Number of the eSIM</value>
    [property: JsonPropertyName("eid")]
        string Eid
);
