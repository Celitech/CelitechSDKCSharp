```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Models;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var input = new TopUpEsimRequest("1111222233334444555000", 1, "2023-11-01", "2023-11-20");

var response = await client.Purchases.TopUpEsimAsync(input);

Console.WriteLine(response);

```
