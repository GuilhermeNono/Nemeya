using Idp.Domain.Database.Entity.Interfaces;

namespace Idp.Domain.Database.Repository;

public interface IReadRepository<TEntity, in TId> : IRepository where TEntity : class, IEntity<TId>, new()
{
    Task<TEntity?> FindById(TId id);
    Task<bool> Exists(TId id);
}
