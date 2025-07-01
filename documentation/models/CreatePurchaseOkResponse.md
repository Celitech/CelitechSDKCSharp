# CreatePurchaseOkResponse

**Properties**

| Name     | Type                             | Required | Description |
| :------- | :------------------------------- | :------- | :---------- |
| Purchase | CreatePurchaseOkResponsePurchase | ❌       |             |
| Profile  | CreatePurchaseOkResponseProfile  | ❌       |             |

# CreatePurchaseOkResponsePurchase

**Properties**

| Name        | Type   | Required | Description                                                                |
| :---------- | :----- | :------- | :------------------------------------------------------------------------- |
| Id          | string | ❌       | ID of the purchase                                                         |
| PackageId   | string | ❌       | ID of the package                                                          |
| StartDate   | string | ❌       | Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ' |
| EndDate     | string | ❌       | End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'   |
| CreatedDate | string | ❌       | Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'        |
| StartTime   | double | ❌       | Epoch value representing the start time of the package's validity          |
| EndTime     | double | ❌       | Epoch value representing the end time of the package's validity            |

# CreatePurchaseOkResponseProfile

**Properties**

| Name                 | Type   | Required | Description                        |
| :------------------- | :----- | :------- | :--------------------------------- |
| Iccid                | string | ❌       | ID of the eSIM                     |
| ActivationCode       | string | ❌       | QR Code of the eSIM as base64      |
| ManualActivationCode | string | ❌       | Manual Activation Code of the eSIM |
