using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class BlockTransactionNotFoundException(Guid blockId) : InternalException(ErrorMessage.Exception.BlockTransactionNotFound(blockId))
{
    
}