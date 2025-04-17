using Idp.CrossCutting.Exceptions.Http.Unauthorized.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Unauthorized;

public class LoginNotFoundException : UnauthorizedException
{
    public LoginNotFoundException() : base(ErrorMessage.Exception.LoginNotFound())
    {
    }
}