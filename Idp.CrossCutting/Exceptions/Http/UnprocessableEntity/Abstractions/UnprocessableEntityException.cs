using System.Net;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;

public abstract class UnprocessableEntityException(string message) : TreatableException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
    
}
