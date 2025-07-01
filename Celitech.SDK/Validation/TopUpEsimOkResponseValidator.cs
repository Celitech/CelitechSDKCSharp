namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class TopUpEsimOkResponseValidator : AbstractValidator<TopUpEsimOkResponse?>
{
    public TopUpEsimOkResponseValidator()
    {
        RuleFor(TopUpEsimOkResponse => TopUpEsimOkResponse.Profile)
            .Custom(
                (topUpEsimOkResponseProfile, context) =>
                {
                    if (topUpEsimOkResponseProfile != null)
                    {
                        var validator = new TopUpEsimOkResponseProfileValidator();
                        var result = validator.Validate(topUpEsimOkResponseProfile);
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
