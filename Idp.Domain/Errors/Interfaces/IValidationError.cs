namespace Idp.Domain.Errors.Interfaces;

public interface IValidationError : IHttpError
{
    HttpError[]? Errors { get; set; }
}