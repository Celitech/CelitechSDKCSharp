namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetAccessTokenRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetAccessTokenRequestValidator : AbstractValidator<GetAccessTokenRequest>
{
    public GetAccessTokenRequestValidator() { }
}
