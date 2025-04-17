using System.Net;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.NotFound.Abstractions;

public abstract class NotFoundException(string message) : TreatableException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
