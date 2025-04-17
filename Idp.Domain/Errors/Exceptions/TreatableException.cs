using System.Net;
using Idp.Domain.Errors.Abstractions;
using Serilog;
using Serilog.Core;

namespace Idp.Domain.Errors.Exceptions;

public abstract class TreatableException : Exception, ITreatableException
{
    public virtual HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
    public string? Code => StatusCode.ToString();

    private readonly Lazy<Logger> _logger = new (() => new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger());

    protected Logger Logger => _logger.Value;

    protected TreatableException(string message) : base(message)
    {
    }

    public virtual IEnumerable<Error> ThrowHandledException()
    {
        Logger.Error(this, Message);
        return [new HttpError
        {
            StatusCode = (int)StatusCode,
            Code = Code,
            Description = Message
        }];
    }
}
