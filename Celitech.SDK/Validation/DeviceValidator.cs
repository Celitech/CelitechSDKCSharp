namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class DeviceValidator : AbstractValidator<Device?>
{
    public DeviceValidator()
    {
        RuleFor(Device => Device.Oem)
            .NotNull()
            .WithMessage("Field oem is required and cannot be null.");
        RuleFor(Device => Device.HardwareName)
            .NotNull()
            .WithMessage("Field hardwareName is required and cannot be null.");
        RuleFor(Device => Device.HardwareModel)
            .NotNull()
            .WithMessage("Field hardwareModel is required and cannot be null.");
        RuleFor(Device => Device.Eid)
            .NotNull()
            .WithMessage("Field eid is required and cannot be null.");
    }
}
