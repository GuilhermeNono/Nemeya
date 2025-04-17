using Idp.CrossCutting.Exceptions.Http.BadRequest.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.BadRequest;

public class EmailIsAlreadyInUseException(string email) : BadRequestException(ErrorMessage.Exception.EmailIsAlreadyInUseException(email))
{
    
}
