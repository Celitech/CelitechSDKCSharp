# Celitech C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=Celitech%2FC%23)
[![nuget shield](https://img.shields.io/nuget/v/Celitech.SDK)](https://nuget.org/packages/Celitech.SDK)

The Celitech C# library provides convenient access to the Celitech APIs from C#.

## Table of Contents

- [Documentation](#documentation)
- [Installation](#installation)
- [Usage](#usage)
- [Exception Handling](#exception-handling)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Forward Compatible Enums](#forward-compatible-enums)
- [Contributing](#contributing)

## Documentation

API reference documentation is available [here](https://docs.celitech.com/).

## Installation

```sh
dotnet add package Celitech.SDK
```

## Usage

Instantiate and use the client with the following:

```csharp
using Celitech.SDK;

var client = new CelitechClient("<client id>", "<client secret>");
await client.Destinations.ListDestinationsAsync();
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Celitech.SDK;

try {
    var response = await client.Destinations.ListDestinationsAsync();
} catch (CelitechClientApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Destinations.ListDestinationsAsync(
    new RequestOptions {
        MaxRetries = 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Destinations.ListDestinationsAsync(
    new RequestOptions {
        Timeout = TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Celitech.SDK;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Destinations.ListDestinationsAsync().WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Destinations.ListDestinationsAsync(
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Destinations.ListDestinationsAsync(
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using Celitech.SDK;

// Using a built-in value
var createPurchaseV2RequestLanguage = CreatePurchaseV2RequestLanguage.En;

// Using a custom value
var customCreatePurchaseV2RequestLanguage = CreatePurchaseV2RequestLanguage.FromCustom("custom-value");

// Using in a switch statement
switch (createPurchaseV2RequestLanguage.Value)
{
    case CreatePurchaseV2RequestLanguage.Values.En:
        Console.WriteLine("En");
        break;
    default:
        Console.WriteLine($"Unknown value: {createPurchaseV2RequestLanguage.Value}");
        break;
}

// Explicit casting
string createPurchaseV2RequestLanguageString = (string)CreatePurchaseV2RequestLanguage.En;
CreatePurchaseV2RequestLanguage createPurchaseV2RequestLanguageFromString = (CreatePurchaseV2RequestLanguage)"en";
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
