using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Person;

public class PersonRepository : CrudRepository<PersonEntity, Guid>, IPersonRepository
{
    public PersonRepository(MainContext context) : base(context)
    {
    }
}