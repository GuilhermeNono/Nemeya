using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Client;

public class ClientNotFoundException() : UnprocessableEntityException(ErrorMessage.Exception.ClientNotFound())
{
    
}