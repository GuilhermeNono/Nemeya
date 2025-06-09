using Idp.Domain.Database.Repository;
using Idp.Domain.Entities;

namespace Idp.Domain.Repositories;

public interface ISigningKeyRepository : ICrudRepository<SigningKeyEntity, Guid>
{
    Task<SigningKeyEntity?> FindLatestIssueKey();
}