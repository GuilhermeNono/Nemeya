using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Authentication;

public class RefreshNotFoundException() : UnprocessableEntityException(ErrorMessage.Exception.RefreshNotFound())
{
    
}