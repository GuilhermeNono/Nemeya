using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Entity;

public class EntityNotFound : UnprocessableEntityException
{
    protected EntityNotFound(long id, string entityName) : base(ErrorMessage.Exception.EntityNotFound(id, entityName))
    {
    }  
    protected EntityNotFound(Guid id, string entityName) : base(ErrorMessage.Exception.EntityNotFound(id, entityName))
    {
    }

    public EntityNotFound(string message) : base(message)
    {
    }
}
