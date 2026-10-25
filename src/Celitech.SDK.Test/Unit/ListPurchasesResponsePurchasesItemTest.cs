using NUnit.Framework;

namespace Celitech.SDK.Tests;

/// <summary>
/// Round-trip coverage for <c>global::Celitech.SDK.ListPurchasesResponsePurchasesItem</c>.
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
public class ListPurchasesResponsePurchasesItemTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"4973fa15-6979-4daa-9cf3-672620df819c\",\"startDate\":\"2023-10-31T22:00:00.000Z\",\"endDate\":\"2023-11-20T21:59:59.000Z\",\"duration\":30,\"createdDate\":\"2023-10-20T00:00:00.000Z\",\"startTime\":3.34,\"endTime\":6.14,\"createdAt\":6.84,\"package\":{\"id\":\"4973fa15-6979-4daa-9cf3-672620df819c\",\"dataLimitInBytes\":1073741824,\"dataLimitInGB\":1,\"destination\":\"FRA\",\"destinationISO2\":\"FR\",\"destinationName\":\"France\",\"priceInCents\":10000},\"esim\":{\"iccid\":\"1111222233334444555000\"},\"source\":\"API\",\"purchaseType\":\"First Purchase\",\"referenceId\":\"abc111222333444\"}";

        var instance =
            TestJson.Deserialize<global::Celitech.SDK.ListPurchasesResponsePurchasesItem>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::Celitech.SDK.ListPurchasesResponsePurchasesItem did not round-trip."
        );
    }
}
