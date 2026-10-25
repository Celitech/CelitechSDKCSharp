using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[Serializable]
public record GetEsimDeviceResponseDevice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Name of the OEM</value>
    [JsonPropertyName("oem")]
    public required string Oem { get; set; }

    /// <value>Name of the Device</value>
    [JsonPropertyName("hardwareName")]
    public required string HardwareName { get; set; }

    /// <value>Model of the Device</value>
    [JsonPropertyName("hardwareModel")]
    public required string HardwareModel { get; set; }

    /// <value>Serial Number of the eSIM</value>
    [JsonPropertyName("eid")]
    public required string Eid { get; set; }

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
    public virtual bool Equals(GetEsimDeviceResponseDevice? other)
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
            && ValueEquality.AreEqual(Oem, other.Oem)
            && ValueEquality.AreEqual(HardwareName, other.HardwareName)
            && ValueEquality.AreEqual(HardwareModel, other.HardwareModel)
            && ValueEquality.AreEqual(Eid, other.Eid)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Oem);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HardwareName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HardwareModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Eid);
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
