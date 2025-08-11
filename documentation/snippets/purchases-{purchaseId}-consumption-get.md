```csharp
using Celitech.SDK;
using Celitech.SDK.Config;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var response = await client.Purchases.GetPurchaseConsumptionAsync("4973fa15-6979-4daa-9cf3-672620df819c");

Console.WriteLine(response);

```
