using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TopUpEsimRequest(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")] string Iccid,
    /// <value>Size of the package in GB. The available options are 0.5, 1, 2, 3, 5, 8, 20, 50GB</value>
    [property: JsonPropertyName("dataLimitInGB")] double DataLimitInGb,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</value>
    [property:
        JsonPropertyName("startDate"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> StartDate = default,
    /// <value>End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</value>
    [property:
        JsonPropertyName("endDate"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> EndDate = default,
    /// <value>Duration of the package in days. Available values are 1, 2, 7, 14, 30, or 90. Either provide startDate/endDate or duration.</value>
    [property:
        JsonPropertyName("duration"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<double> Duration = default,
    /// <value>Email address where the purchase confirmation email will be sent (excluding QR Code & activation steps).</value>
    [property:
        JsonPropertyName("email"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> Email = default,
    /// <value>An identifier provided by the partner to link this purchase to their booking or transaction for analytics and debugging purposes.</value>
    [property:
        JsonPropertyName("referenceId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> ReferenceId = default,
    /// <value>Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("emailBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<string> EmailBrand = default,
    /// <value>Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months.</value>
    [property:
        JsonPropertyName("startTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<double> StartTime = default,
    /// <value>Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time.</value>
    [property:
        JsonPropertyName("endTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ] Optional<double> EndTime = default
);
