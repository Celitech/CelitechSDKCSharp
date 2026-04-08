namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for ListPurchasesOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListPurchasesOkResponseValidator : AbstractValidator<ListPurchasesOkResponse>
{
    public ListPurchasesOkResponseValidator()
    {
        RuleFor(ListPurchasesOkResponse => ListPurchasesOkResponse.Purchases)
            .NotNull()
            .WithMessage("Field purchases is required and cannot be null.");
    }
}
