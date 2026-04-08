namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetEsimDeviceOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetEsimDeviceOkResponseValidator : AbstractValidator<GetEsimDeviceOkResponse>
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
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field device is required and cannot be null.");
    }
}
