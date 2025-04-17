using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class BlockCorruptionException(Guid blockId) : InternalException(ErrorMessage.Exception.BlockCorruption(blockId))
{
    
}