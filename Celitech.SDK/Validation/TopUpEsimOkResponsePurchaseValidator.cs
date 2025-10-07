namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class TopUpEsimOkResponsePurchaseValidator : AbstractValidator<TopUpEsimOkResponsePurchase?>
{
    public TopUpEsimOkResponsePurchaseValidator()
    {
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.PackageId)
            .NotNull()
            .WithMessage("Field packageId is required and cannot be null.");
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required and cannot be null.");
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required and cannot be null.");
        RuleFor(TopUpEsimOkResponsePurchase => TopUpEsimOkResponsePurchase.CreatedDate)
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
    }
}
