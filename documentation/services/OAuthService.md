# OAuthService

A list of all methods in the `OAuthService` service. Click on the method name to view detailed information about that method.

| Methods                                     | Description                       |
| :------------------------------------------ | :-------------------------------- |
| [GetAccessTokenAsync](#getaccesstokenasync) | This endpoint was added by liblab |

## GetAccessTokenAsync

This endpoint was added by liblab

- HTTP Method: `POST`
- Endpoint: `/oauth2/token`

**Parameters**

| Name  | Type                  | Required | Description       |
| :---- | :-------------------- | :------- | :---------------- |
| input | GetAccessTokenRequest | ✅       | The request body. |

**Return Type**

`GetAccessTokenOkResponse`

**Example Usage Code Snippet**

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

var input = new GetAccessTokenRequest();

var response = await client.OAuth.GetAccessTokenAsync(input);

Console.WriteLine(response);
```
