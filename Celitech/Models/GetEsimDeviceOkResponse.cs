using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimDeviceOkResponse([property: JsonPropertyName("device")] Device Device);
