namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseOkResponsePurchase model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseOkResponsePurchaseValidator
    : AbstractValidator<CreatePurchaseOkResponsePurchase>
{
    public CreatePurchaseOkResponsePurchaseValidator()
    {
        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.PackageId)
            .NotNull()
            .WithMessage("Field packageId is required and cannot be null.");

        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.CreatedDate)
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
    }
}
