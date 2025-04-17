using Idp.Domain.Database.Context;
using Idp.Domain.Database.Entity.Interfaces;

namespace Idp.Domain.Database.Repository;

public interface IViewRepository<TEntity> : IEFContext where TEntity : class, IEntityView, new()
{
    Task<IAsyncEnumerable<TEntity>> FindAsync();
}
