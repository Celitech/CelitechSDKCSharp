using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimDeviceOkResponse([property: JsonPropertyName("device")] Device Device1);
