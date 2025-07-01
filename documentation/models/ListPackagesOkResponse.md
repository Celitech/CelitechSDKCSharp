# ListPackagesOkResponse

**Properties**

| Name        | Type           | Required | Description                                                                                                                                                                                                                                                                                    |
| :---------- | :------------- | :------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Packages1   | List<Packages> | ❌       |                                                                                                                                                                                                                                                                                                |
| AfterCursor | string         | ❌       | The cursor value representing the end of the current page of results. Use this cursor value as the "afterCursor" parameter in your next request to retrieve the subsequent page of results. It ensures that you continue fetching data from where you left off, facilitating smooth pagination |

# Packages

**Properties**

| Name             | Type   | Required | Description                                      |
| :--------------- | :----- | :------- | :----------------------------------------------- |
| Id               | string | ❌       | ID of the package                                |
| Destination      | string | ❌       | ISO representation of the package's destination. |
| DataLimitInBytes | double | ❌       | Size of the package in Bytes                     |
| MinDays          | double | ❌       | Min number of days for the package               |
| MaxDays          | double | ❌       | Max number of days for the package               |
| PriceInCents     | double | ❌       | Price of the package in cents                    |
