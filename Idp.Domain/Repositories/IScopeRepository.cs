using Idp.Domain.Database.Repository;
using Idp.Domain.Entities;

namespace Idp.Domain.Repositories;

public interface IScopeRepository : IReadRepository<ScopeEntity, int>
{
    Task<IEnumerable<ScopeEntity>> Find();
    Task<ScopeEntity?> FindByNames(string names);
}