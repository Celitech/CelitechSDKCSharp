using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[Serializable]
public record GetEsimResponseEsim : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the eSIM</value>
    [JsonPropertyName("iccid")]
    public required string Iccid { get; set; }

    /// <value>SM-DP+ Address</value>
    [JsonPropertyName("smdpAddress")]
    public required string SmdpAddress { get; set; }

    /// <value>QR Code of the eSIM as base64</value>
    [JsonPropertyName("activationCode")]
    public required string ActivationCode { get; set; }

    /// <value>The manual activation code</value>
    [JsonPropertyName("manualActivationCode")]
    public required string ManualActivationCode { get; set; }

    /// <value>Status of the eSIM, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR'</value>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <value>Status of the eSIM connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'</value>
    [JsonPropertyName("connectivityStatus")]
    public required string ConnectivityStatus { get; set; }

    /// <value>Indicates whether the eSIM is currently eligible for a top-up. This flag should be checked before attempting a top-up request.</value>
    [JsonPropertyName("isTopUpAllowed")]
    public required bool IsTopUpAllowed { get; set; }

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
    public virtual bool Equals(GetEsimResponseEsim? other)
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
            && ValueEquality.AreEqual(Iccid, other.Iccid)
            && ValueEquality.AreEqual(SmdpAddress, other.SmdpAddress)
            && ValueEquality.AreEqual(ActivationCode, other.ActivationCode)
            && ValueEquality.AreEqual(ManualActivationCode, other.ManualActivationCode)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(ConnectivityStatus, other.ConnectivityStatus)
            && ValueEquality.AreEqual(IsTopUpAllowed, other.IsTopUpAllowed)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Iccid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SmdpAddress);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ActivationCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ManualActivationCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConnectivityStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsTopUpAllowed);
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
