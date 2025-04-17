using Idp.Domain.Errors.Abstractions;

namespace Idp.Domain.Errors;

public class HttpError : Error
{
    public HttpError(string? code, string? description) : base(code, description)
    {
    }

    public HttpError()
    {
    }
}