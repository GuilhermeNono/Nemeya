using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Users;

public class UserNotFoundException : UnprocessableEntityException
{
    public UserNotFoundException(Guid id) : base(ErrorMessage.Exception.UserNotFound(id))
    {
    }
}