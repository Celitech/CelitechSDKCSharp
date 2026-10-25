using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[Serializable]
public record ListPackagesResponsePackagesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the package</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>ISO3 representation of the package's destination.</value>
    [JsonPropertyName("destination")]
    public required string Destination { get; set; }

    /// <value>ISO2 representation of the package's destination.</value>
    [JsonPropertyName("destinationISO2")]
    public required string DestinationIso2 { get; set; }

    /// <value>Size of the package in Bytes. A value of `-1` indicates an unlimited package.</value>
    [JsonPropertyName("dataLimitInBytes")]
    public required double DataLimitInBytes { get; set; }

    /// <value>Size of the package in GB. A value of `-1` indicates an unlimited (date-based) package.</value>
    [JsonPropertyName("dataLimitInGB")]
    public required double DataLimitInGb { get; set; }

    /// <value>Min number of days for the package</value>
    [JsonPropertyName("minDays")]
    public required double MinDays { get; set; }

    /// <value>Max number of days for the package</value>
    [JsonPropertyName("maxDays")]
    public required double MaxDays { get; set; }

    /// <value>Price of the package in cents</value>
    [JsonPropertyName("priceInCents")]
    public required double PriceInCents { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(ListPackagesResponsePackagesItem? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Destination, other.Destination)
            && ValueEquality.AreEqual(DestinationIso2, other.DestinationIso2)
            && ValueEquality.AreEqual(DataLimitInBytes, other.DataLimitInBytes)
            && ValueEquality.AreEqual(DataLimitInGb, other.DataLimitInGb)
            && ValueEquality.AreEqual(MinDays, other.MinDays)
            && ValueEquality.AreEqual(MaxDays, other.MaxDays)
            && ValueEquality.AreEqual(PriceInCents, other.PriceInCents)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Destination);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DestinationIso2);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataLimitInBytes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataLimitInGb);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MinDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PriceInCents);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
