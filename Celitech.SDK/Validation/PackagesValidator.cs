namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for Packages model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class PackagesValidator : AbstractValidator<Packages>
{
    public PackagesValidator()
    {
        RuleFor(Packages => Packages.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(Packages => Packages.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(Packages => Packages.DestinationIso2)
            .NotNull()
            .WithMessage("Field destinationISO2 is required and cannot be null.");
        RuleFor(Packages => Packages.DataLimitInBytes)
            .NotNull()
            .WithMessage("Field dataLimitInBytes is required and cannot be null.");
        RuleFor(Packages => Packages.MinDays)
            .NotNull()
            .WithMessage("Field minDays is required and cannot be null.");
        RuleFor(Packages => Packages.MaxDays)
            .NotNull()
            .WithMessage("Field maxDays is required and cannot be null.");
        RuleFor(Packages => Packages.PriceInCents)
            .NotNull()
            .WithMessage("Field priceInCents is required and cannot be null.");
    }
}
