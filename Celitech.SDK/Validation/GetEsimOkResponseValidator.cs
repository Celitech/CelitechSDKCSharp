namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetEsimOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetEsimOkResponseValidator : AbstractValidator<GetEsimOkResponse>
{
    public GetEsimOkResponseValidator()
    {
        RuleFor(GetEsimOkResponse => GetEsimOkResponse.Esim)
            .Custom(
                (getEsimOkResponseEsim, context) =>
                {
                    if (getEsimOkResponseEsim != null)
                    {
                        var validator = new GetEsimOkResponseEsimValidator();
                        var result = validator.Validate(getEsimOkResponseEsim);
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
