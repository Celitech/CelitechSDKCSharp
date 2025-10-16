# GetEsimHistoryOkResponse

**Properties**

| Name | Type                         | Required | Description |
| :--- | :--------------------------- | :------- | :---------- |
| Esim | GetEsimHistoryOkResponseEsim | ✅       |             |

# GetEsimHistoryOkResponseEsim

**Properties**

| Name     | Type          | Required | Description    |
| :------- | :------------ | :------- | :------------- |
| Iccid    | string        | ✅       | ID of the eSIM |
| History1 | List<History> | ✅       |                |

# History

**Properties**

| Name       | Type   | Required | Description                                                                                                                         |
| :--------- | :----- | :------- | :---------------------------------------------------------------------------------------------------------------------------------- |
| Status     | string | ✅       | The status of the eSIM at a given time, possible values are 'RELEASED', 'DOWNLOADED', 'INSTALLED', 'ENABLED', 'DELETED', or 'ERROR' |
| StatusDate | string | ✅       | The date when the eSIM status changed in the format 'yyyy-MM-ddThh:mm:ssZZ'                                                         |
| Date       | double | ❌       | Epoch value representing the date when the eSIM status changed                                                                      |
