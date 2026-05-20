# V2Service

A list of all methods in the `V2Service` service. Click on the method name to view detailed information about that method.

| Methods                                         | Description                                                                    |
| :---------------------------------------------- | :----------------------------------------------------------------------------- |
| [CreatePurchaseV2Async](#createpurchasev2async) | This endpoint is used to purchase a new eSIM by providing the package details. |

## CreatePurchaseV2Async

This endpoint is used to purchase a new eSIM by providing the package details.

- HTTP Method: `POST`
- Endpoint: `/purchases/v2`

**Parameters**

| Name   | Type                    | Required | Description       |
| :----- | :---------------------- | :------- | :---------------- |
| input  | CreatePurchaseV2Request | ✅       | The request body. |
| accept | string                  | ✅       |                   |

**Return Type**

`object`

**Example Usage Code Snippet**

```csharp
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Models;

var config = new CelitechConfig{
    ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var input = new CreatePurchaseV2Request();

var response = await client.V2.CreatePurchaseV2Async(input, "application/json");

Console.WriteLine(response);
```
