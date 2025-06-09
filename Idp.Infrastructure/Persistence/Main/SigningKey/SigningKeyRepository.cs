using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.SigningKey.Queries.Find.LatestIssueKey;

namespace Idp.Infrastructure.Persistence.Main.SigningKey;

public class SigningKeyRepository : CrudRepository<SigningKeyEntity, Guid>, ISigningKeyRepository
{
    public SigningKeyRepository(MainContext context) : base(context)
    {
    }

    public Task<SigningKeyEntity?> FindLatestIssueKey()
    {
        var query = new LatestIssueKeyQuery(new LatestIssueKeyFilter());
        
        return QuerySingle(query);
    }
}