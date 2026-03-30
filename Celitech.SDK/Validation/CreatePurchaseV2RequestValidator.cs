namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseV2Request model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseV2RequestValidator : AbstractValidator<CreatePurchaseV2Request>
{
    public CreatePurchaseV2RequestValidator()
    {
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Quantity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Minimum for quantity is 1.")
            .LessThanOrEqualTo(5)
            .WithMessage("Minimum for quantity is 5.")
            .NotNull()
            .WithMessage("Field quantity is required and cannot be null.");
    }
}
