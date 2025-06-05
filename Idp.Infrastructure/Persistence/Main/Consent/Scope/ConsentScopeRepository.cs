using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Consent.Scope;

public class ConsentScopeRepository : CrudRepository<ConsentScopeEntity, long>, IConsentScopeRepository
{
    public ConsentScopeRepository(MainContext context) : base(context)
    {
    }
}