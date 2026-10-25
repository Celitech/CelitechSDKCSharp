using NUnit.Framework;

namespace Celitech.SDK.Tests;

/// <summary>
/// Round-trip coverage for <c>global::Celitech.SDK.ListPackagesResponsePackagesItem</c>.
/// </summary>
/// <remarks>
/// Asserts the wire document the model was built from comes back out of it unchanged — not merely
/// that serialization runs. Starting from JSON rather than from a constructed instance is what
/// makes one emitter cover both output modes: the legacy positional record and the fernMode
/// `required`/`init` record are constructed differently but deserialize from the same document, so
/// nothing here has to know which shape it is looking at. It is also the stronger assertion, since
/// a property whose C# name diverges from its wire name fails this and would pass a test that only
/// compared an instance to itself.
/// </remarks>
[TestFixture]
public class ListPackagesResponsePackagesItemTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"4973fa15-6979-4daa-9cf3-672620df819c\",\"destination\":\"FRA\",\"destinationISO2\":\"FR\",\"dataLimitInBytes\":1073741824,\"dataLimitInGB\":1,\"minDays\":8.44,\"maxDays\":30,\"priceInCents\":10000}";

        var instance = TestJson.Deserialize<global::Celitech.SDK.ListPackagesResponsePackagesItem>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::Celitech.SDK.ListPackagesResponsePackagesItem did not round-trip."
        );
    }
}
