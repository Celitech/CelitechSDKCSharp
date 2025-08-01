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

var response = await client.ESim.GetEsimMacAsync("1111222233334444555000");

Console.WriteLine(response);

```
