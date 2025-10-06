using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record History(
    /// <value>The status of the eSIM at a given time, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR'</value>
    [property: JsonPropertyName("status")]
        string Status,
    /// <value>The date when the eSIM status changed in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("statusDate")]
        string StatusDate,
    /// <value>Epoch value representing the date when the eSIM status changed</value>
    [property:
        JsonPropertyName("date"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Date = null
);
