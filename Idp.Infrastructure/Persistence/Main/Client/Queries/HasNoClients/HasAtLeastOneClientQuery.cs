using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Client.Queries.HasNoClients;

public class HasAtLeastOneClientQuery : CustomQuery<bool>
{
    protected override void Prepare()
    {
        Add("""
            SELECT 
                CASE WHEN COUNT(*) > 0 
                    THEN CONVERT(BIT, 1) 
                    ELSE CONVERT(BIT, 0) END AS Value
            FROM Ath_Clients
            """);
    }
}