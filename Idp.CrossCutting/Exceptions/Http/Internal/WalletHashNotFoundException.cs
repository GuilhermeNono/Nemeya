using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class WalletHashNotFoundException(string hash) : UnprocessableEntityException(ErrorMessage.Exception.WalletHashNotFound(hash))
{
    
}