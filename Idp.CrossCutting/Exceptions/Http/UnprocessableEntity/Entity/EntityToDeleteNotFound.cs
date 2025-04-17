using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Abstractions;
using Idp.CrossCutting.Messages;

namespace Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Entity;

public class EntityToDeleteNotFound : UnprocessableEntityException
{
    public EntityToDeleteNotFound(string entity) : base(ErrorMessage.Exception.EntityDeleteNotFoundException(entity))
    {
    }
}
