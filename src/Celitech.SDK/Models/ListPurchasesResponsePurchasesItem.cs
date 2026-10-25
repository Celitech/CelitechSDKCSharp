using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[Serializable]
public record ListPurchasesResponsePurchasesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the purchase</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    /// <value>End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    /// <value>Duration of the package in days. Possible values are 1, 2, 7, 14, 30, or 90. `null` for unlimited (date-based) packages.</value>
    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    /// <value>Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [JsonPropertyName("createdDate")]
    public required DateTime CreatedDate { get; set; }

    /// <value>Epoch value representing the start time of the package's validity</value>
    [JsonPropertyName("startTime")]
    public double? StartTime { get; set; }

    /// <value>Epoch value representing the end time of the package's validity</value>
    [JsonPropertyName("endTime")]
    public double? EndTime { get; set; }

    /// <value>Epoch value representing the date of creation of the purchase</value>
    [JsonPropertyName("createdAt")]
    public double? CreatedAt { get; set; }

    [JsonPropertyName("package")]
    public required ListPurchasesResponsePurchasesItemPackage Package { get; set; }

    [JsonPropertyName("esim")]
    public required ListPurchasesResponsePurchasesItemEsim Esim { get; set; }

    /// <value>The `source` indicates whether the purchase was made from the API, dashboard, landing-page, promo-page or iframe. For purchases made before September 8, 2023, the value will be displayed as 'Not available'.</value>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <value>The `purchaseType` indicates whether this is the initial purchase that creates the eSIM (First Purchase) or a subsequent top-up on an existing eSIM (Top-up Purchase).</value>
    [JsonPropertyName("purchaseType")]
    public required string PurchaseType { get; set; }

    /// <value>The `referenceId` that was provided by the partner during the purchase or top-up flow. This identifier can be used for analytics and debugging purposes.</value>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

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
    public virtual bool Equals(ListPurchasesResponsePurchasesItem? other)
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
            && ValueEquality.AreEqual(StartDate, other.StartDate)
            && ValueEquality.AreEqual(EndDate, other.EndDate)
            && ValueEquality.AreEqual(Duration, other.Duration)
            && ValueEquality.AreEqual(CreatedDate, other.CreatedDate)
            && ValueEquality.AreEqual(StartTime, other.StartTime)
            && ValueEquality.AreEqual(EndTime, other.EndTime)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(Package, other.Package)
            && ValueEquality.AreEqual(Esim, other.Esim)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(PurchaseType, other.PurchaseType)
            && ValueEquality.AreEqual(ReferenceId, other.ReferenceId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Duration);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Package);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Esim);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PurchaseType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReferenceId);
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
