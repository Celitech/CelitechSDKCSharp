using Celitech;
using Celitech.Config;
using Environment = Celitech.Http.Environment;

var config = new CelitechConfig { ClientId = "CLIENT_ID", ClientSecret = "CLIENT_SECRET" };

var client = new CelitechClient(config);

var response = await client.Destinations.ListDestinationsAsync();

Console.WriteLine(response);
