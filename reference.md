# Reference

## DestinationsService

### `ListDestinationsAsync`

`GET /destinations`

List Destinations

## PackagesService

### `ListPackagesAsync`

`GET /packages`

List Packages

**Parameters:**

- `destination`
- `dataLimitInGb`
- `startDate`
- `endDate`
- `afterCursor`
- `limit`
- `startTime`
- `endTime`
- `includeUnlimited`

## PurchasesService

### `CreatePurchaseV2Async`

`POST /purchases/v2`

Create Purchase V2

### `ListPurchasesAsync`

`GET /purchases`

List Purchases

**Parameters:**

- `purchaseId`
- `iccid`
- `afterDate`
- `beforeDate`
- `email`
- `referenceId`
- `afterCursor`
- `limit`
- `after`
- `before`

### `CreatePurchaseAsync`

`POST /purchases`

Create Purchase

### `TopUpEsimAsync`

`POST /purchases/topup`

Top-up eSIM

### `EditPurchaseAsync`

`POST /purchases/edit`

Edit Purchase

### `GetPurchaseConsumptionAsync`

`GET /purchases/{purchaseId}/consumption`

Get Purchase Consumption

**Parameters:**

- `purchaseId` (required)

## ESimService

### `GetEsimAsync`

`GET /esim`

Get eSIM

**Parameters:**

- `iccid` (required)

### `GetEsimDeviceAsync`

`GET /esim/{iccid}/device`

Get eSIM Device

**Parameters:**

- `iccid` (required)

### `GetEsimHistoryAsync`

`GET /esim/{iccid}/history`

Get eSIM History

**Parameters:**

- `iccid` (required)

### `SuspendEsimAsync`

`POST /esim/{iccid}/suspend`

Suspend eSIM

**Parameters:**

- `iccid` (required)

## IFrameService

### `TokenAsync`

`POST /iframe/token`

Generate Token

## OAuthService

### `GetAccessTokenAsync`

`POST /oauth2/token`
