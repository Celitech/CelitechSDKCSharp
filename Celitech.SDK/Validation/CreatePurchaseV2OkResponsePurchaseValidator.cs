namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseV2OkResponsePurchase model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseV2OkResponsePurchaseValidator
    : AbstractValidator<CreatePurchaseV2OkResponsePurchase>
{
    public CreatePurchaseV2OkResponsePurchaseValidator()
    {
        RuleFor(CreatePurchaseV2OkResponsePurchase => CreatePurchaseV2OkResponsePurchase.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(CreatePurchaseV2OkResponsePurchase => CreatePurchaseV2OkResponsePurchase.PackageId)
            .NotNull()
            .WithMessage("Field packageId is required and cannot be null.");
        RuleFor(CreatePurchaseV2OkResponsePurchase =>
                CreatePurchaseV2OkResponsePurchase.CreatedDate
            )
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
    }
}
