namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class DeviceValidator : AbstractValidator<Device?>
{
    public DeviceValidator() { }
}
