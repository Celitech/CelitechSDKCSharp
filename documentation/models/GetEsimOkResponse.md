# GetEsimOkResponse

**Properties**

| Name | Type                  | Required | Description |
| :--- | :-------------------- | :------- | :---------- |
| Esim | GetEsimOkResponseEsim | ❌       |             |

# GetEsimOkResponseEsim

**Properties**

| Name                 | Type   | Required | Description                                                                                                     |
| :------------------- | :----- | :------- | :-------------------------------------------------------------------------------------------------------------- |
| Iccid                | string | ❌       | ID of the eSIM                                                                                                  |
| SmdpAddress          | string | ❌       | SM-DP+ Address                                                                                                  |
| ManualActivationCode | string | ❌       | The manual activation code                                                                                      |
| Status               | string | ❌       | Status of the eSIM, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR' |
