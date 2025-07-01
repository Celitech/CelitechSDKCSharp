# DestinationsService

A list of all methods in the `DestinationsService` service. Click on the method name to view detailed information about that method.

| Methods                                         | Description       |
| :---------------------------------------------- | :---------------- |
| [ListDestinationsAsync](#listdestinationsasync) | List Destinations |

## ListDestinationsAsync

List Destinations

- HTTP Method: `GET`
- Endpoint: `/destinations`

**Return Type**

`ListDestinationsOkResponse`

**Example Usage Code Snippet**

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

var response = await client.Destinations.ListDestinationsAsync();

Console.WriteLine(response);
```
