using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopes;
using Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByName;
using Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByNames;

namespace Idp.Infrastructure.Persistence.Main.Scope;

public class ScopeRepository(MainContext context) : ReadRepository<ScopeEntity, int>(context), IScopeRepository
{
    public Task<IEnumerable<ScopeEntity>> Find() => Task.FromResult(Query(new FindScopesQuery()));
    public Task<ScopeEntity?> FindByName(string names) => QuerySingle(new FindScopesByNameQuery(new FindScopesByNameFilter(names)));

    public Task<IEnumerable<ScopeEntity>> FindByNames(string[] scopes) =>
        Task.FromResult(Query(new FindScopesByNamesQuery(new FindScopesByNamesFilter(scopes))));
}