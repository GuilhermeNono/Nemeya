using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Users;

public class UserEmailNotFoundException() : UnprocessableEntityException(ErrorMessage.Exception.UserEmailNotFound())
{
    
}
