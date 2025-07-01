```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Models;
using Environment = Celitech.SDK.Http.Environment;

var config = new CelitechConfig{
    Environment = Environment.Default,
	ClientId = "CLIENTID",
	ClientSecret = "CLIENTSECRET"
};

var client = new CelitechClient(config);

var input = new CreatePurchaseV2Request("FRA", 1, "2023-11-01", "2023-11-20", 1);

var response = await client.Purchases.CreatePurchaseV2Async(input);

Console.WriteLine(response);

```
