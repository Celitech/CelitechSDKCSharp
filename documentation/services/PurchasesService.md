# PurchasesService

A list of all methods in the `PurchasesService` service. Click on the method name to view detailed information about that method.

| Methods                                                     | Description                                                                                                                                                                                                                                                                                                            |
| :---------------------------------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [CreatePurchaseV2Async](#createpurchasev2async)             | This endpoint is used to purchase a new eSIM by providing the package details.                                                                                                                                                                                                                                         |
| [ListPurchasesAsync](#listpurchasesasync)                   | This endpoint can be used to list all the successful purchases made between a given interval.                                                                                                                                                                                                                          |
| [TopUpEsimAsync](#topupesimasync)                           | This endpoint is used to top-up an eSIM with the previously associated destination by providing an existing ICCID and the package details. The top-up is only feasible for eSIMs in "ENABLED" or "INSTALLED" state. You can check this state using the Get eSIM Status endpoint.                                       |
| [EditPurchaseAsync](#editpurchaseasync)                     | This endpoint allows you to modify the dates of an existing package with a future activation start time. Editing can only be performed for packages that have not been activated, and it cannot change the package size. The modification must not change the package duration category to ensure pricing consistency. |
| [GetPurchaseConsumptionAsync](#getpurchaseconsumptionasync) | This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.                                                                                                                                       |

## CreatePurchaseV2Async

This endpoint is used to purchase a new eSIM by providing the package details.

- HTTP Method: `POST`
- Endpoint: `/purchases/v2`

**Parameters**

| Name  | Type                    | Required | Description       |
| :---- | :---------------------- | :------- | :---------------- |
| input | CreatePurchaseV2Request | ✅       | The request body. |

**Return Type**

`List<CreatePurchaseV2OkResponse>`

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

var input = new CreatePurchaseV2Request("FRA", 1, "2023-11-01", "2023-11-20", 1);

var response = await client.Purchases.CreatePurchaseV2Async(input);

Console.WriteLine(response);
```

## ListPurchasesAsync

This endpoint can be used to list all the successful purchases made between a given interval.

- HTTP Method: `GET`
- Endpoint: `/purchases`

**Parameters**

| Name        | Type   | Required | Description                                                                                                                                                                                                         |
| :---------- | :----- | :------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| iccid       | string | ❌       | ID of the eSIM                                                                                                                                                                                                      |
| afterDate   | string | ❌       | Start date of the interval for filtering purchases in the format 'yyyy-MM-dd'                                                                                                                                       |
| beforeDate  | string | ❌       | End date of the interval for filtering purchases in the format 'yyyy-MM-dd'                                                                                                                                         |
| referenceId | string | ❌       | The referenceId that was provided by the partner during the purchase or topup flow.                                                                                                                                 |
| afterCursor | string | ❌       | To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data. |
| limit       | double | ❌       | Maximum number of purchases to be returned in the response. The value must be greater than 0 and less than or equal to 100. If not provided, the default value is 20                                                |
| after       | double | ❌       | Epoch value representing the start of the time interval for filtering purchases                                                                                                                                     |
| before      | double | ❌       | Epoch value representing the end of the time interval for filtering purchases                                                                                                                                       |

**Return Type**

`ListPurchasesOkResponse`

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

var response = await client.Purchases.ListPurchasesAsync();

Console.WriteLine(response);
```

## TopUpEsimAsync

This endpoint is used to top-up an eSIM with the previously associated destination by providing an existing ICCID and the package details. The top-up is only feasible for eSIMs in "ENABLED" or "INSTALLED" state. You can check this state using the Get eSIM Status endpoint.

- HTTP Method: `POST`
- Endpoint: `/purchases/topup`

**Parameters**

| Name  | Type             | Required | Description       |
| :---- | :--------------- | :------- | :---------------- |
| input | TopUpEsimRequest | ✅       | The request body. |

**Return Type**

`TopUpEsimOkResponse`

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

var input = new TopUpEsimRequest("1111222233334444555000", 1, "2023-11-01", "2023-11-20");

var response = await client.Purchases.TopUpEsimAsync(input);

Console.WriteLine(response);
```

## EditPurchaseAsync

This endpoint allows you to modify the dates of an existing package with a future activation start time. Editing can only be performed for packages that have not been activated, and it cannot change the package size. The modification must not change the package duration category to ensure pricing consistency.

- HTTP Method: `POST`
- Endpoint: `/purchases/edit`

**Parameters**

| Name  | Type                | Required | Description       |
| :---- | :------------------ | :------- | :---------------- |
| input | EditPurchaseRequest | ✅       | The request body. |

**Return Type**

`EditPurchaseOkResponse`

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

var input = new EditPurchaseRequest("ae471106-c8b4-42cf-b83a-b061291f2922", "2023-11-01", "2023-11-20");

var response = await client.Purchases.EditPurchaseAsync(input);

Console.WriteLine(response);
```

## GetPurchaseConsumptionAsync

This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.

- HTTP Method: `GET`
- Endpoint: `/purchases/{purchaseId}/consumption`

**Parameters**

| Name       | Type   | Required | Description        |
| :--------- | :----- | :------- | :----------------- |
| purchaseId | string | ✅       | ID of the purchase |

**Return Type**

`GetPurchaseConsumptionOkResponse`

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

var response = await client.Purchases.GetPurchaseConsumptionAsync("4973fa15-6979-4daa-9cf3-672620df819c");

Console.WriteLine(response);
```
