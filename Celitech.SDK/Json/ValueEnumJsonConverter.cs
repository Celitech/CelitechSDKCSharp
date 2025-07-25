using System.Text.Json;
using System.Text.Json.Serialization;
using Celitech.SDK.Models;

namespace Celitech.SDK.Json;

internal class ValueEnumJsonConverter<TValueEnum, TEnumType> : JsonConverter<TValueEnum>
    where TValueEnum : ValueEnum<TEnumType>, new()
{
    public override TValueEnum? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        object? value = null;

        if (typeof(TEnumType) == typeof(string))
        {
            value = reader.GetString();
        }
        else if (typeof(TEnumType) == typeof(int) || typeof(TEnumType) == typeof(long))
        {
            value = reader.GetInt64();
        }
        else if (typeof(TEnumType) == typeof(double) || typeof(TEnumType) == typeof(float))
        {
            value = reader.GetDouble();
        }
        else if (typeof(TEnumType) == typeof(bool))
        {
            value = reader.GetBoolean();
        }
        else
        {
            throw new JsonException(
                $"Attempted to deserialize unsupported ValueEnum type: {typeof(TEnumType)}"
            );
        }

        if (value is null)
        {
            return null;
        }

        return new TValueEnum { Value = (TEnumType)Convert.ChangeType(value, typeof(TEnumType)) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TValueEnum valueEnum,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, valueEnum.Value, options);
    }
}
