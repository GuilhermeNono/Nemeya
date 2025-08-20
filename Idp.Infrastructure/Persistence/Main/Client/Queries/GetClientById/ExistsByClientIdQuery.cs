using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Client.Queries.GetClientById;

public class ExistsByClientIdQuery(ExistsByClientIdFilter filter) : CustomQuery<ExistsByClientIdFilter, bool>(filter)
{
    protected override void Prepare()
    {
        Add($"""
            SELECT 1 as Value
              FROM Ath_Clients 
             WHERE ClientId = {Param(x => x.ClientId)}
            """);
    }
}