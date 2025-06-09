using Idp.Domain.Entities;
using Idp.Infrastructure.EFCore.Query.CustomQuery;

namespace Idp.Infrastructure.Persistence.Main.SigningKey.Queries.Find.LatestIssueKey;

public class LatestIssueKeyQuery(LatestIssueKeyFilter filter) : CustomQuery<LatestIssueKeyFilter, SigningKeyEntity>(filter)
{
    protected override void Prepare()
    {
        Add($"""
                 SELECT *
                   FROM Ath_SigningKeys 
                   WHERE CanIssue = {Param(x => x.CanIssue)}
             """);
    }
}