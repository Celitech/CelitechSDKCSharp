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

var input = new TopUpEsimRequest("1111222233334444555000", 1, "2023-11-01", "2023-11-20");

var response = await client.Purchases.TopUpEsimAsync(input);

Console.WriteLine(response);

```
