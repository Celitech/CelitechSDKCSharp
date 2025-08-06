```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Models;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var input = new EditPurchaseRequest("ae471106-c8b4-42cf-b83a-b061291f2922", "2023-11-01", "2023-11-20");

var response = await client.Purchases.EditPurchaseAsync(input);

Console.WriteLine(response);

```
