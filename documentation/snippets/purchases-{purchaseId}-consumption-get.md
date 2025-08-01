```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Environment = Celitech.SDK.Http.Environment;

var config = new CelitechConfig{
    Environment = Environment.Default,
	ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var response = await client.Purchases.GetPurchaseConsumptionAsync("4973fa15-6979-4daa-9cf3-672620df819c");

Console.WriteLine(response);

```
