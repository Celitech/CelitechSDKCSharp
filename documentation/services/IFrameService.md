# IFrameService

A list of all methods in the `IFrameService` service. Click on the method name to view detailed information about that method.

| Methods                   | Description                                   |
| :------------------------ | :-------------------------------------------- |
| [TokenAsync](#tokenasync) | Generate a new token to be used in the iFrame |

## TokenAsync

Generate a new token to be used in the iFrame

- HTTP Method: `POST`
- Endpoint: `/iframe/token`

**Return Type**

`TokenOkResponse`

**Example Usage Code Snippet**

```csharp
using Celitech.SDK;
using Celitech.SDK.Config;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var response = await client.IFrame.TokenAsync();

Console.WriteLine(response);
```
