using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByName;

public class FindScopesByNameQuery(FindScopesByNameFilter filter) : CustomQuery<FindScopesByNameFilter, ScopeEntity>(filter)
{
    protected override void Prepare()
    {
        Add($"""
            SELECT *
              FROM Ath_Scopes
             WHERE Name in ({Param(x => x.FormatedNames)})
            """);
    }
}