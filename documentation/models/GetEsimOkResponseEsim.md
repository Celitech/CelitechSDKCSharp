# GetEsimOkResponseEsim

**Properties**

| Name                 | Type   | Required | Description                                                                                                                    |
| :------------------- | :----- | :------- | :----------------------------------------------------------------------------------------------------------------------------- |
| Iccid                | string | ✅       | ID of the eSIM                                                                                                                 |
| SmdpAddress          | string | ✅       | SM-DP+ Address                                                                                                                 |
| ActivationCode       | string | ✅       | QR Code of the eSIM as base64                                                                                                  |
| ManualActivationCode | string | ✅       | The manual activation code                                                                                                     |
| Status               | string | ✅       | Status of the eSIM, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR'                |
| IsTopUpAllowed       | bool   | ✅       | Indicates whether the eSIM is currently eligible for a top-up. This flag should be checked before attempting a top-up request. |
