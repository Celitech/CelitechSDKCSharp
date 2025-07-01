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

var input = new EditPurchaseRequest("ae471106-c8b4-42cf-b83a-b061291f2922", "2023-11-01", "2023-11-20");

var response = await client.Purchases.EditPurchaseAsync(input);

Console.WriteLine(response);

```
