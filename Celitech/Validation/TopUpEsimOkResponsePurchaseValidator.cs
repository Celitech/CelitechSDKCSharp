namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for TopUpEsimOkResponsePurchase model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TopUpEsimOkResponsePurchaseValidator : AbstractValidator<TopUpEsimOkResponsePurchase>
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
