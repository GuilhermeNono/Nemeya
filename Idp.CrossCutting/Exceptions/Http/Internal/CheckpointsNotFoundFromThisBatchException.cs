using Idp.CrossCutting.Exceptions.Http.Internal.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Internal;

public class CheckpointsNotFoundFromThisBatchException : InternalException
{
    public CheckpointsNotFoundFromThisBatchException() : base(ErrorMessage.Exception.CheckpointsNotFoundFromThisBatch())
    {
    }
}