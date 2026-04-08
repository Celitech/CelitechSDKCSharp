namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for Device model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class DeviceValidator : AbstractValidator<Device>
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
