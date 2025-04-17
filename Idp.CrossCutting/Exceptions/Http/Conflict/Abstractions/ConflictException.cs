using System.Net;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.Conflict.Abstractions;

public abstract class ConflictException(string message) : TreatableException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
