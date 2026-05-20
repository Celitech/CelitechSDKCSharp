# EsimService

A list of all methods in the `EsimService` service. Click on the method name to view detailed information about that method.

| Methods                       | Description |
| :---------------------------- | :---------- |
| [GetESimAsync](#getesimasync) | Get eSIM    |

## GetESimAsync

Get eSIM

- HTTP Method: `GET`
- Endpoint: `/esim`

**Parameters**

| Name   | Type   | Required | Description    |
| :----- | :----- | :------- | :------------- |
| accept | string | ✅       |                |
| iccid  | string | ❌       | ID of the eSIM |

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

var response = await client.Esim.GetESimAsync("application/json");

Console.WriteLine(response);
```
