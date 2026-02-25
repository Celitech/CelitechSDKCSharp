namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetEsimHistoryOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetEsimHistoryOkResponseValidator : AbstractValidator<GetEsimHistoryOkResponse>
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
            )
            .NotNull()
            .WithMessage("Field esim is required and cannot be null.");
    }
}
