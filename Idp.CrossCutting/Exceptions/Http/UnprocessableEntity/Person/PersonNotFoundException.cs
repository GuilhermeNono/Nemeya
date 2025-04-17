using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Person;

public class PersonNotFoundException() : UnprocessableEntityException(ErrorMessage.Exception.PersonNotFound())
{
    
}