using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByNames;

public class FindScopesByNamesQuery(FindScopesByNamesFilter filter) : CustomQuery<FindScopesByNamesFilter, ScopeEntity>(filter)
{
    protected override void Prepare()
    {
        Add($"""
             SELECT *
               FROM Ath_Scopes
              WHERE Name in ({Param(x => x.Names)})
             """);
    }
}