using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopes;

public class FindScopesQuery : CustomQuery<ScopeEntity>
{
    protected override void Prepare()
    {
        Add("""
            SELECT * 
              FROM Ath_Scopes
            """);
    }
}