namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for Destinations model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class DestinationsValidator : AbstractValidator<Destinations>
{
    public DestinationsValidator()
    {
        RuleFor(Destinations => Destinations.Name)
            .NotNull()
            .WithMessage("Field name is required and cannot be null.");
        RuleFor(Destinations => Destinations.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(Destinations => Destinations.DestinationIso2)
            .NotNull()
            .WithMessage("Field destinationISO2 is required and cannot be null.");
        RuleFor(Destinations => Destinations.SupportedCountries)
            .NotNull()
            .WithMessage("Field supportedCountries is required and cannot be null.");
    }
}
