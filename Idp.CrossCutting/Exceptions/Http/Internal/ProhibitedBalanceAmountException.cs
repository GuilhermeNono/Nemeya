using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class ProhibitedBalanceAmountException(decimal points) : InternalException(ErrorMessage.Exception.ProhibitedBalanceAmount(points))
{
    
}