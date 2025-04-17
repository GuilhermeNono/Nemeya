using Idp.CrossCutting.Exceptions.Http.NotFound.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Wallet;

public class WalletUserNotFoundException(Guid userId) : NotFoundException(ErrorMessage.Exception.WalletUserNotFound(userId))
{
    
}