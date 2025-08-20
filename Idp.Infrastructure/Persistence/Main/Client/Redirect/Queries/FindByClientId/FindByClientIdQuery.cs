using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.FindByClientId;

public class FindByClientIdQuery(FindByClientIdFilter filter) : CustomQuery<FindByClientIdFilter, ClientEntity>(filter)
{
    protected override void Prepare()
    {
        Add($"""
            SELECT *
              FROM Ath_Clients
             WHERE ClientId = {Param(x => x.ClientId)}
            """);
    }
}