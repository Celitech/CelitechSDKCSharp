namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.TopUpEsimOkResponsePurchase model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TopUpEsimOkResponsePurchaseValidator
    : AbstractValidator<global::Celitech.SDK.Models.TopUpEsimOkResponsePurchase>
{
    public TopUpEsimOkResponsePurchaseValidator()
    {
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.PackageId)
            .NotNull()
            .WithMessage("Field packageId is required and cannot be null.");

        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.CreatedDate)
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
    }
}
