# GetPurchaseConsumptionOkResponse

**Properties**

| Name                      | Type   | Required | Description                                                                     |
| :------------------------ | :----- | :------- | :------------------------------------------------------------------------------ |
| DataUsageRemainingInBytes | double | ✅       | Remaining balance of the package in bytes. Returns `-1` for unlimited packages. |
| DataUsageRemainingInGb    | double | ✅       | Remaining balance of the package in GB. Returns `-1` for unlimited packages.    |
| Status                    | string | ✅       | Status of the connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'        |
