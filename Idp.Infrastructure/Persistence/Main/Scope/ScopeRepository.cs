using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Scope;

public class ScopeRepository : ReadRepository<ScopeEntity, int>, IScopeRepository
{
    public ScopeRepository(MainContext context) : base(context)
    {
    }
}