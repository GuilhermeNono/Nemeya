using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity;

public class SignatureIsInvalidException() : UnprocessableEntityException(ErrorMessage.Exception.SignatureIsInvalid())
{
    
}