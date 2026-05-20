# TopupService

A list of all methods in the `TopupService` service. Click on the method name to view detailed information about that method.

| Methods                           | Description                                                                                                                                                                                                                                           |
| :-------------------------------- | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [TopUpESimAsync](#topupesimasync) | This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag. |

## TopUpESimAsync

This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag.

- HTTP Method: `POST`
- Endpoint: `/purchases/topup`

**Parameters**

| Name   | Type             | Required | Description       |
| :----- | :--------------- | :------- | :---------------- |
| input  | TopUpESimRequest | ✅       | The request body. |
| accept | string           | ✅       |                   |

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

var input = new TopUpESimRequest();

var response = await client.Topup.TopUpESimAsync(input, "application/json");

Console.WriteLine(response);
```
