using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class ExternalOrderWithInternalPaginationException : InternalException
{
    public ExternalOrderWithInternalPaginationException() : base(ErrorMessage.Exception.ExternalOrderWithInternalPagination())
    {
    }
}