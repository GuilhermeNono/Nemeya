using Idp.CrossCutting.Exceptions.Http.BadRequest.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.BadRequest;

public class InvalidClientException(string client) : BadRequestException(ErrorMessage.Exception.InvalidClient(client))
{
    
}