using Idp.CrossCutting.Exceptions.Http.NotFound.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Wallet;

public class WalletNotFoundException(Guid walletId) : NotFoundException(ErrorMessage.Exception.WalletNotFound(walletId))
{
    
}