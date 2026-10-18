namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.GetEsimDeviceOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetEsimDeviceOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.GetEsimDeviceOkResponse>
{
    public GetEsimDeviceOkResponseValidator()
    {
        RuleFor(GetEsimDeviceOkResponse => GetEsimDeviceOkResponse.Device)
            .Custom(
                (device, context) =>
                {
                    if (device != null)
                    {
                        var validator = new DeviceValidator();
                        var result = validator.Validate(device);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                var propertyPath = string.IsNullOrEmpty(failure.PropertyName)
                                    ? "Device"
                                    : $"Device.{failure.PropertyName}";
                                context.AddFailure(propertyPath, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field device is required and cannot be null.");
    }
}
