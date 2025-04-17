using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class ExternalOrderWithTreatablePagination : InternalException
{
    public ExternalOrderWithTreatablePagination() : base(ErrorMessage.Exception
        .ExternalOrderWithInternalPagination())
    {
    }
}
