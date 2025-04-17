using System.Text.Json.Serialization;
using Idp.Domain.Errors.Interfaces;

namespace Idp.Domain.Errors;

public class ValidationError : HttpError, IValidationError
{
    public ValidationError(string? code, string? description) : base(code, description)
    {
    }

    public ValidationError()
    {
    }

    [JsonPropertyOrder(4)]
    public HttpError[]? Errors { get; set; }
}