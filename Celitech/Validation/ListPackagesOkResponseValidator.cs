namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for ListPackagesOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListPackagesOkResponseValidator : AbstractValidator<ListPackagesOkResponse>
{
    public ListPackagesOkResponseValidator()
    {
        RuleFor(ListPackagesOkResponse => ListPackagesOkResponse.Packages)
            .NotNull()
            .WithMessage("Field packages is required and cannot be null.");
    }
}
