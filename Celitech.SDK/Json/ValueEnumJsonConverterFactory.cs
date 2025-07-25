using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Celitech.SDK.Models;

namespace Celitech.SDK.Json;

internal class ValueEnumJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (typeToConvert.BaseType is null || !typeToConvert.BaseType.IsGenericType)
        {
            return false;
        }

        var baseType = typeToConvert.BaseType.GetGenericTypeDefinition();
        return baseType == typeof(ValueEnum<>);
    }

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var genericArguments =
            typeToConvert.BaseType?.GetGenericArguments()
            ?? throw new InvalidOperationException("Failed to get generic argument from ValueEnum");
        var jsonConverterType = typeof(ValueEnumJsonConverter<,>).MakeGenericType(
            typeToConvert,
            genericArguments[0]
        );
        var instance =
            Activator.CreateInstance(jsonConverterType)
            ?? throw new InvalidOperationException(
                "Failed to create ValueEnumJsonConverter instance"
            );
        return (JsonConverter)instance;
    }
}
