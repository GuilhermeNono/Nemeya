using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Permissions;

public class PermissionRoleNotFoundException(string role) : UnprocessableEntityException(ErrorMessage.Exception.PermissionRoleNotFound(role))
{
    
}
