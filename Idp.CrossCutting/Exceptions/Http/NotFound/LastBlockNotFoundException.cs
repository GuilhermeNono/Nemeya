using Idp.CrossCutting.Exceptions.Http.NotFound.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.NotFound;

public class LastBlockNotFoundException() : NotFoundException(ErrorMessage.Exception.LastBlockNotFound())
{
    
}