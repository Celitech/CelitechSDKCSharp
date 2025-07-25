using System.Collections;
using System.Net;
using System.Text.Json.Serialization;

namespace Celitech.SDK.Http.Serialization;

public static class Serializer
{
    /// <summary>
    /// Serializes types into strings based on the RFC-6570 URI Template and OpenAPI specifications.
    /// <see cref="https://datatracker.ietf.org/doc/html/rfc6570"/>
    /// <see cref="https://swagger.io/docs/specification/serialization/"/>
    /// </summary>
    public static string Serialize<T>(
        string key,
        T value,
        SerializationStyle style,
        bool explode = true
    )
    {
        return value switch
        {
            null or string or bool or int or long or double => SerializePrimitive(
                key,
                value,
                style
            ),
            IEnumerable e => SerializeEnumerable(key, e, style, explode),
            object o => SerializeObject(key, o, style, explode),
        };
    }

    private static string SerializeValue(object? value)
    {
        return value switch
            {
                null => "null",
                string s => WebUtility.UrlEncode(s),
                bool b => b.ToString().ToLowerInvariant(),
                int or long or double => value.ToString(),
                IEnumerable e => SerializeEnumerable(
                    string.Empty,
                    e,
                    SerializationStyle.Simple,
                    false
                ),
                not null => SerializeObject(string.Empty, value, SerializationStyle.Simple, false),
            } ?? string.Empty;
    }

    private static string SerializePrimitive(string key, object? value, SerializationStyle style)
    {
        return style switch
        {
            SerializationStyle.Label => $".{SerializeValue(value)}",
            SerializationStyle.Matrix => $";{SerializeValue(value)}",
            SerializationStyle.Form => $"{key}={SerializeValue(value)}",
            _ => SerializeValue(value),
        };
    }

    private static string SerializeEnumerable(
        string key,
        IEnumerable enumerable,
        SerializationStyle style,
        bool explode
    )
    {
        var array = enumerable as object[] ?? enumerable.Cast<object>().ToArray();
        var serializedValues = array.Select(SerializeValue);

        switch (style)
        {
            case SerializationStyle.Simple:
                return string.Join(",", serializedValues);
            case SerializationStyle.Label:
                return explode
                    ? string.Join(".", serializedValues)
                    : $".{string.Join(",", serializedValues)}";
            case SerializationStyle.Matrix:
                return explode
                    ? string.Join($";{key}=", serializedValues)
                    : $";{key}={string.Join(",", serializedValues)}";
        }

        if (explode)
            return string.Join(
                $"&",
                array.Select(e => Serialize(key, e, SerializationStyle.Form, explode))
            );

        var separator = style switch
        {
            SerializationStyle.SpaceDelimited => " ",
            SerializationStyle.PipeDelimited => "|",
            _ => ",",
        };

        return $"{key}={string.Join(separator, serializedValues)}";
    }

    private static string SerializeObject<T>(
        string key,
        T o,
        SerializationStyle style,
        bool explode
    )
        where T : class
    {
        var properties = o.GetType()
            .GetProperties()
            .Select(p =>
            {
                // Use JsonPropertyNameAttribute for property name if available
                var name = p.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                    .FirstOrDefault()
                    is JsonPropertyNameAttribute jsonProperty
                    ? jsonProperty.Name
                    : p.Name;
                return (name, value: p.GetValue(o));
            })
            .Where(p => p.value != null);

        switch (style)
        {
            case SerializationStyle.Simple:
                return string.Join(
                    ",",
                    explode
                        ? properties.Select(p => $"{p.name}={SerializeValue(p.value)}")
                        : properties.Select(p => $"{p.name},{SerializeValue(p.value)}")
                );
            case SerializationStyle.Label:
                return explode
                    ? string.Join(
                        ".",
                        properties.Select(p => $"{p.name}={SerializeValue(p.value)}")
                    )
                    : $"."
                        + string.Join(
                            ",",
                            properties.Select(p => $"{p.name}={SerializeValue(p.value)}")
                        );
            case SerializationStyle.Matrix:
                return explode
                    ? string.Join(
                        $";",
                        properties.Select(p => $"{p.name}={SerializeValue(p.value)}")
                    )
                    : $";{string.Join(",", properties.Select(p => $"{p.name}={SerializeValue(p.value)}"))}";
            case SerializationStyle.DeepObject:
                return string.Join(
                    "&",
                    properties.Select(p => $"{key}[{p.name}]={SerializeValue(p.value)}")
                );
            default:
                // Form style
                return explode
                    ? string.Join(
                        "&",
                        properties.Select(p => $"{p.name}={SerializeValue(p.value)}")
                    )
                    : $"{key}={string.Join(",", properties.Select((p) => $"{p.name},{SerializeValue(p.value)}"))}";
        }
    }
}
