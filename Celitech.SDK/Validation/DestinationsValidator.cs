namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class DestinationsValidator : AbstractValidator<Destinations?>
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
