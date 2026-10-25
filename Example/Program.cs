using Celitech.SDK;
using Environment = Celitech.SDK.Http.Environment;

var client = new CelitechClient("CLIENT_ID", "CLIENT_SECRET");

var response = await client.Destinations.ListDestinationsAsync();

Console.WriteLine(response);
