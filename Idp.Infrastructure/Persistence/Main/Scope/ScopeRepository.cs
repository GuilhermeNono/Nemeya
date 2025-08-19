using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopes;
using Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByName;

namespace Idp.Infrastructure.Persistence.Main.Scope;

public class ScopeRepository(MainContext context) : ReadRepository<ScopeEntity, int>(context), IScopeRepository
{
    public Task<IEnumerable<ScopeEntity>> Find() => Task.FromResult(Query(new FindScopesQuery()));
    public Task<IEnumerable<ScopeEntity>> FindByNames(string[] names) => Task.FromResult(Query(new FindScopesByNameQuery(new FindScopesByNameFilter(names))));
}