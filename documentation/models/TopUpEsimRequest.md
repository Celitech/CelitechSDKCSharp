# TopUpEsimRequest

**Properties**

| Name          | Type                     | Required | Description                                                                                                                                                                                                            |
| :------------ | :----------------------- | :------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Iccid         | string                   | ✅       | ID of the eSIM                                                                                                                                                                                                         |
| DataLimitInGb | double                   | ✅       | Size of the package in GB. The available options are 0.5, 1, 2, 3, 5, 8, 20GB                                                                                                                                          |
| StartDate     | string                   | ❌       | Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.                                                                         |
| EndDate       | string                   | ❌       | End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.                                                                                                       |
| Duration      | TopUpEsimRequestDuration | ❌       | Duration of the package in days. Available values are 1, 2, 7, 14, 30, or 90. Either provide startDate/endDate or duration.                                                                                            |
| Email         | string                   | ❌       | Email address where the purchase confirmation email will be sent (excluding QR Code & activation steps).                                                                                                               |
| ReferenceId   | string                   | ❌       | An identifier provided by the partner to link this purchase to their booking or transaction for analytics and debugging purposes.                                                                                      |
| EmailBrand    | string                   | ❌       | Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only. |
| StartTime     | double                   | ❌       | Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months.                                                                |
| EndTime       | double                   | ❌       | Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time.                                                                                                     |

# TopUpEsimRequestDuration

Duration of the package in days. Available values are 1, 2, 7, 14, 30, or 90. Either provide startDate/endDate or duration.

**Properties**

| Name | Type   | Required | Description |
| :--- | :----- | :------- | :---------- |
| \_1  | double | ✅       | 1           |
| \_2  | double | ✅       | 2           |
| \_7  | double | ✅       | 7           |
| \_14 | double | ✅       | 14          |
| \_30 | double | ✅       | 30          |
| \_90 | double | ✅       | 90          |
