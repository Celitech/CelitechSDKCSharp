```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Environment = Celitech.SDK.Http.Environment;

var config = new CelitechConfig{
    Environment = Environment.Default,
	ClientId = "CLIENTID",
	ClientSecret = "CLIENTSECRET"
};

var client = new CelitechClient(config);

var response = await client.ESim.GetEsimHistoryAsync("1111222233334444555000");

Console.WriteLine(response);

```
