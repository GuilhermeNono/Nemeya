using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.IsValidRedirect;

public class IsValidRedirectQuery(IsValidRedirectFilter filter) : CustomQuery<IsValidRedirectFilter, bool>(filter)
{
    protected override void Prepare()
    {
        Add($"""
            SELECT Case when COUNT(*) > 0 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END AS Value 
              FROM Ath_ClientRedirects
            WHERE ClientId = {Param(x => x.ClientId)}
              AND Uri = {Param(x => x.RedirectUri)}
            """);
    }
}