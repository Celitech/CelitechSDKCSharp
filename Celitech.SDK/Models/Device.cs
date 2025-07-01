using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Device(
    /// <value>Name of the OEM</value>
    [property:
        JsonPropertyName("oem"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Oem = null,
    /// <value>Name of the Device</value>
    [property:
        JsonPropertyName("hardwareName"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? HardwareName = null,
    /// <value>Model of the Device</value>
    [property:
        JsonPropertyName("hardwareModel"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? HardwareModel = null,
    /// <value>Serial Number of the eSIM</value>
    [property:
        JsonPropertyName("eid"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Eid = null
);
