# TokenService

A list of all methods in the `TokenService` service. Click on the method name to view detailed information about that method.

| Methods                                   | Description                                   |
| :---------------------------------------- | :-------------------------------------------- |
| [GenerateTokenAsync](#generatetokenasync) | Generate a new token to be used in the iFrame |

## GenerateTokenAsync

Generate a new token to be used in the iFrame

- HTTP Method: `POST`
- Endpoint: `/iframe/token`

**Parameters**

| Name   | Type   | Required | Description |
| :----- | :----- | :------- | :---------- |
| accept | string | ✅       |             |

**Return Type**

`object`

**Example Usage Code Snippet**

```csharp
using Celitech.SDK;
using Celitech.SDK.Config;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var response = await client.Token.GenerateTokenAsync("application/json");

Console.WriteLine(response);
```
