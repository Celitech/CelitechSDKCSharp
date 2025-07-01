namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimHistoryOkResponseValidator : AbstractValidator<GetEsimHistoryOkResponse?>
{
    public GetEsimHistoryOkResponseValidator()
    {
        RuleFor(GetEsimHistoryOkResponse => GetEsimHistoryOkResponse.Esim)
            .Custom(
                (getEsimHistoryOkResponseEsim, context) =>
                {
                    if (getEsimHistoryOkResponseEsim != null)
                    {
                        var validator = new GetEsimHistoryOkResponseEsimValidator();
                        var result = validator.Validate(getEsimHistoryOkResponseEsim);
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
