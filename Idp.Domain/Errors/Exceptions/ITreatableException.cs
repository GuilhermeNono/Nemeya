using Idp.Domain.Errors.Abstractions;
using Idp.Domain.Errors.Exceptions.Http;

namespace Idp.Domain.Errors.Exceptions;

public interface ITreatableException : IHttpException
{
    IEnumerable<Error> ThrowHandledException();
}
