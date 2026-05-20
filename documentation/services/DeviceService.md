# DeviceService

A list of all methods in the `DeviceService` service. Click on the method name to view detailed information about that method.

| Methods                                   | Description     |
| :---------------------------------------- | :-------------- |
| [GetESimDeviceAsync](#getesimdeviceasync) | Get eSIM Device |

## GetESimDeviceAsync

Get eSIM Device

- HTTP Method: `GET`
- Endpoint: `/esim/{iccid}/device`

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

var response = await client.Device.GetESimDeviceAsync("iccid", "application/json");

Console.WriteLine(response);
```
