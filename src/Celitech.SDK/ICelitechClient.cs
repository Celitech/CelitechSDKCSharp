namespace Celitech.SDK;

/// <summary>
/// Fern-shape root client interface exposing the top-level sub-clients as their interface type. A
/// deeper client is reached through its parent (<c>client.Fleet.Attributes</c>), so only top-level
/// nodes appear here. FSM-144 / FSM-936.
/// </summary>
public partial interface ICelitechClient
{
    public IDestinationsClient Destinations { get; }
    public IPackagesClient Packages { get; }
    public IPurchasesClient Purchases { get; }
    public IESimClient ESim { get; }
    public IIFrameClient IFrame { get; }
}
