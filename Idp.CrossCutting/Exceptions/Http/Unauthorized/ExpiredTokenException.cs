using Idp.CrossCutting.Exceptions.Http.Unauthorized.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.Unauthorized;

public class ExpiredTokenException() : UnauthorizedException(ErrorMessage.Exception.ExpiredTokenException())
{
    
}