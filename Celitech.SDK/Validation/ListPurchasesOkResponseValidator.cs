namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class ListPurchasesOkResponseValidator : AbstractValidator<ListPurchasesOkResponse?>
{
    public ListPurchasesOkResponseValidator()
    {
        RuleFor(ListPurchasesOkResponse => ListPurchasesOkResponse.Purchases1)
            .NotNull()
            .WithMessage("Field purchases is required and cannot be null.");
    }
}
