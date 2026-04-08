using System.Text.Json.Serialization;

namespace Celitech.Models;

public record TokenOkResponse(
    /// <value>The generated token</value>
    [property: JsonPropertyName("token")] string Token
);
