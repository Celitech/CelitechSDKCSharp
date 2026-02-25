namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for ListDestinationsOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListDestinationsOkResponseValidator : AbstractValidator<ListDestinationsOkResponse>
{
    public ListDestinationsOkResponseValidator()
    {
        RuleFor(ListDestinationsOkResponse => ListDestinationsOkResponse.Destinations)
            .NotNull()
            .WithMessage("Field destinations is required and cannot be null.");
    }
}
