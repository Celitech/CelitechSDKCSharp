namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class PurchasesValidator : AbstractValidator<Purchases?>
{
    public PurchasesValidator()
    {
        RuleFor(Purchases => Purchases.Esim)
            .Custom(
                (purchasesEsim, context) =>
                {
                    if (purchasesEsim != null)
                    {
                        var validator = new PurchasesEsimValidator();
                        var result = validator.Validate(purchasesEsim);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            );
    }
}
