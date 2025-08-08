using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.SigningKey.Queries.Find.LatestIssueKey;

namespace Idp.Infrastructure.Persistence.Main.SigningKey;

public class SigningKeyRepository(MainContext context)
    : CrudRepository<SigningKeyEntity, Guid>(context), ISigningKeyRepository
{
    public Task<SigningKeyEntity?> FindLatestIssueKey()
    {
        var query = new LatestIssueKeyQuery(new LatestIssueKeyFilter());
        
        return QuerySingle(query);
    }
}