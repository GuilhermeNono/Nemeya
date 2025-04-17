using Idp.CrossCutting.Exceptions.Http.Conflict.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Conflict;

public class InsufficientBalanceException() : ConflictException(ErrorMessage.Exception.InsufficientBalance())
{
    
}