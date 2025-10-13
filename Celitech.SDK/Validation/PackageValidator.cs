namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class PackageValidator : AbstractValidator<Package?>
{
    public PackageValidator()
    {
        RuleFor(Package => Package.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(Package => Package.DataLimitInBytes)
            .NotNull()
            .WithMessage("Field dataLimitInBytes is required and cannot be null.");
        RuleFor(Package => Package.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(Package => Package.DestinationIso2)
            .NotNull()
            .WithMessage("Field destinationISO2 is required and cannot be null.");
        RuleFor(Package => Package.DestinationName)
            .NotNull()
            .WithMessage("Field destinationName is required and cannot be null.");
        RuleFor(Package => Package.PriceInCents)
            .NotNull()
            .WithMessage("Field priceInCents is required and cannot be null.");
    }
}
