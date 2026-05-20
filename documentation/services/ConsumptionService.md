# ConsumptionService

A list of all methods in the `ConsumptionService` service. Click on the method name to view detailed information about that method.

| Methods                                                     | Description                                                                                                                                                                      |
| :---------------------------------------------------------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [GetPurchaseConsumptionAsync](#getpurchaseconsumptionasync) | This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages. |

## GetPurchaseConsumptionAsync

This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.

- HTTP Method: `GET`
- Endpoint: `/purchases/{purchaseId}/consumption`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| purchaseId | string | ✅       |             |
| accept     | string | ✅       |             |

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

var response = await client.Consumption.GetPurchaseConsumptionAsync("purchaseId", "application/json");

Console.WriteLine(response);
```
