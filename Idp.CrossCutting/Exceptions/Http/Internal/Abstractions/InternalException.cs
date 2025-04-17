using System.Net;
using Idp.Domain.Errors;
using Idp.Domain.Errors.Abstractions;
using Idp.Domain.Errors.Exceptions;

namespace Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;

public abstract class InternalException : TreatableException
{
    private readonly string _message;

    protected InternalException(string message) : base(message)
    {
        _message = message;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

    public override IEnumerable<Error> ThrowHandledException()
    {
        Logger.Error(this, _message);
        return [new HttpError
        {
            StatusCode = (int)StatusCode,
            Code = Code,
        }];
    }
}
