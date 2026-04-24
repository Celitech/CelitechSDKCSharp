using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record BadRequest(
    /// <value>Message of the error</value>
    [property:
        JsonPropertyName("message"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> Message = default
);
