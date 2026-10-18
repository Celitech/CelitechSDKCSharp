namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.SuspendEsimOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class SuspendEsimOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.SuspendEsimOkResponse>
{
    public SuspendEsimOkResponseValidator()
    {
        RuleFor(SuspendEsimOkResponse => SuspendEsimOkResponse.Message)
            .NotNull()
            .WithMessage("Field message is required and cannot be null.");
    }
}
