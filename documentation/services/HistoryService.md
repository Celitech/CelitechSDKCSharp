# HistoryService

A list of all methods in the `HistoryService` service. Click on the method name to view detailed information about that method.

| Methods                                     | Description      |
| :------------------------------------------ | :--------------- |
| [GetESimHistoryAsync](#getesimhistoryasync) | Get eSIM History |

## GetESimHistoryAsync

Get eSIM History

- HTTP Method: `GET`
- Endpoint: `/esim/{iccid}/history`

**Parameters**

| Name   | Type   | Required | Description |
| :----- | :----- | :------- | :---------- |
| iccid  | string | ✅       |             |
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

var response = await client.History.GetESimHistoryAsync("iccid", "application/json");

Console.WriteLine(response);
```
