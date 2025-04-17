using System.Net;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.BadRequest.Abstractions;

public abstract class BadRequestException(string message) : TreatableException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
