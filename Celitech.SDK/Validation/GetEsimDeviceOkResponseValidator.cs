namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimDeviceOkResponseValidator : AbstractValidator<GetEsimDeviceOkResponse?>
{
    public GetEsimDeviceOkResponseValidator()
    {
        RuleFor(GetEsimDeviceOkResponse => GetEsimDeviceOkResponse.Device1)
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
