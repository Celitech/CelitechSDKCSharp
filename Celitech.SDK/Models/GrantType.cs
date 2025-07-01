using System.Text.Json.Serialization;
using Celitech.SDK.Json;

namespace Celitech.SDK.Models;

public record GrantType : ValueEnum<string>
{
    internal GrantType(string value)
        : base(value) { }

    public GrantType()
        : base("client_credentials") { }

    public static GrantType ClientCredentials = new("client_credentials");
}
