# Celitech C# SDK 2.0.10

Welcome to the Celitech SDK documentation. This guide will help you get started with integrating and using the Celitech SDK in your project.

## Versions

- API version: `2.0.10`
- SDK version: `2.0.10`

## About the API

Welcome to the CELITECH API documentation!

Useful links: [Homepage](https://www.celitech.com) | [Support email](mailto:devops@celitech.com) | [Blog](https://www.celitech.com/blog/)

# Introduction

This is the reference documentation and schemas for the CELITECH API and webhooks. For tutorials and other documentation please refer to the [CELITECH Documentation](https://docs.celitech.com).

"Partners" refers to online service providers that use our eSIM API. Access levels include Gold, Platinum, and Diamond.

## API

The CELITECH API is designed for use by partner platforms, including both web and mobile applications. It's assumed all endpoint calls are initiated from the backend of an integrated platform.

API URL: `https://api.celitech.net/v1`

## Authentication & Authorization

CELITECH API uses the OAuth 2.0 protocol for authentication and authorization.
The endpoints are protected using client credentials flow which is based on a token exchange. The token has a defined life span (typically 1 hour), after which a new token must be obtained.

To begin, obtain OAuth 2.0 client credentials ( **CLIENT_ID** & **CLIENT_SECRET** ) from the [CELITECH Dashboard](https://www.dashboard.celitech.com/). Then your client application requests an access token from the CELITECH Authorization Server, extracts a token from the response, and sends the token to the CELITECH API that you want to access.

Security Scheme Type: `OAuth2`

Flow type: `clientCredentials`

Token URL: `https://auth.celitech.net/oauth2/token`

## Table of Contents

- [Setup & Configuration](#setup--configuration)
  - [Supported Language Versions](#supported-language-versions)
  - [Installation](#installation)
- [Authentication](#authentication)
  - [OAuth Authentication](#oauth-authentication)
  - [Environment Variables](#environment-variables)
- [Setting a Custom Timeout](#setting-a-custom-timeout)
- [Sample Usage](#sample-usage)
- [Services](#services)
- [Models](#models)
- [License](#license)

# Setup & Configuration

## Supported Language Versions

This SDK is compatible with the following versions: `C# >= .NET 6`

## Installation

To get started with the SDK, we recommend installing using `nuget`:

```bash
dotnet add package Celitech.SDK
```

## Authentication

### OAuth Authentication

The Celitech API uses OAuth 2.0 for authentication.

You need to provide your OAuth credentials when initializing the SDK. Tokens are automatically fetched, cached, and refreshed — you do not need to manage them yourself.

```cs
using Celitech.SDK;
using Celitech.SDK.Config;

var config = new Celitech.SDKConfig()
{
	ClientId = "CLIENT_ID",
	ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);
```

If you need to set or update the OAuth credentials after the SDK initialization, you can use:

```cs
sdk.SetClientId("CLIENT_ID")
sdk.SetClientSecret("CLIENT_SECRET")
```

## Environment Variables

These are the environment variables for the SDK:

| Name          | Description             |
| :------------ | :---------------------- |
| CLIENT_ID     | Client ID parameter     |
| CLIENT_SECRET | Client Secret parameter |

Environment variables are a way to configure your application outside the code. You can set these environment variables on the command line or use your project's existing tooling for managing environment variables.

If you are using a `.env` file, a template with the variable names is provided in the `.env.example` file located in the same directory as this README.

## Setting a Custom Timeout

You can set a custom timeout for the SDK's HTTP requests as follows:

```cs
client.SetTimeout(TimeSpan.FromSeconds(10))
```

# Sample Usage

Below is a comprehensive example demonstrating how to authenticate and call a simple endpoint:

```cs
using Celitech.SDK;
using Celitech.SDK.Config;
using Environment = Celitech.SDK.Http.Environment;

var config = new CelitechConfig
{
  ClientId = "CLIENT_ID",
  ClientSecret = "CLIENT_SECRET"
};

var client = new CelitechClient(config);

var response = await client.Destinations.ListDestinationsAsync();

Console.WriteLine(response);

```

## Services

The SDK provides various services to interact with the API.

Below is a list of all available services:

| Name                                                                 |
| :------------------------------------------------------------------- |
| [DestinationsService](documentation/services/DestinationsService.md) |
| [PackagesService](documentation/services/PackagesService.md)         |
| [PurchasesService](documentation/services/PurchasesService.md)       |
| [ESimService](documentation/services/ESimService.md)                 |
| [IFrameService](documentation/services/IFrameService.md)             |

## Models

The SDK includes several models that represent the data structures used in API requests and responses. These models help in organizing and managing the data efficiently.

Below is a list of all available models:

| Name                                                                                         | Description |
| :------------------------------------------------------------------------------------------- | :---------- |
| [ListDestinationsOkResponse](documentation/models/ListDestinationsOkResponse.md)             |             |
| [ListPackagesOkResponse](documentation/models/ListPackagesOkResponse.md)                     |             |
| [CreatePurchaseV2Request](documentation/models/CreatePurchaseV2Request.md)                   |             |
| [CreatePurchaseV2OkResponse](documentation/models/CreatePurchaseV2OkResponse.md)             |             |
| [ListPurchasesOkResponse](documentation/models/ListPurchasesOkResponse.md)                   |             |
| [CreatePurchaseRequest](documentation/models/CreatePurchaseRequest.md)                       |             |
| [CreatePurchaseOkResponse](documentation/models/CreatePurchaseOkResponse.md)                 |             |
| [TopUpEsimRequest](documentation/models/TopUpEsimRequest.md)                                 |             |
| [TopUpEsimOkResponse](documentation/models/TopUpEsimOkResponse.md)                           |             |
| [EditPurchaseRequest](documentation/models/EditPurchaseRequest.md)                           |             |
| [EditPurchaseOkResponse](documentation/models/EditPurchaseOkResponse.md)                     |             |
| [GetPurchaseConsumptionOkResponse](documentation/models/GetPurchaseConsumptionOkResponse.md) |             |
| [GetEsimOkResponse](documentation/models/GetEsimOkResponse.md)                               |             |
| [GetEsimDeviceOkResponse](documentation/models/GetEsimDeviceOkResponse.md)                   |             |
| [GetEsimHistoryOkResponse](documentation/models/GetEsimHistoryOkResponse.md)                 |             |
| [SuspendEsimOkResponse](documentation/models/SuspendEsimOkResponse.md)                       |             |
| [TokenOkResponse](documentation/models/TokenOkResponse.md)                                   |             |
| [GrantType](documentation/models/GrantType.md)                                               |             |

## License

This SDK is licensed under the MIT License.

See the [LICENSE](LICENSE) file for more details.
