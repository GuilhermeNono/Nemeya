using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Wallet;

public class WalletPublicKeyNotFoundException(string publicKey) : UnprocessableEntityException(ErrorMessage.Exception.WalletPublicKeyNotFound(publicKey))
{
    
}