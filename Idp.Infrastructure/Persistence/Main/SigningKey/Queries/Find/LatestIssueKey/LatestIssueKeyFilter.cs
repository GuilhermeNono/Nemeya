using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.SigningKey.Queries.Find.LatestIssueKey;

public record LatestIssueKeyFilter() : IFilter
{
    public bool CanIssue => true;
}