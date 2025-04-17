using System.Net;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.Unauthorized.Abstractions;

public abstract class UnauthorizedException(string message) : TreatableException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
