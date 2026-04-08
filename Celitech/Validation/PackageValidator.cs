namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for Package model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class PackageValidator : AbstractValidator<Package>
{
    public PackageValidator()
    {
        RuleFor(Package => Package.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(Package => Package.DataLimitInBytes)
            .NotNull()
            .WithMessage("Field dataLimitInBytes is required and cannot be null.");
        RuleFor(Package => Package.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
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
