using Idp.Domain.Database.Entity.Interfaces;
using Idp.Domain.Database.Repository;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.EFCore.Abstractions;

public abstract class ReadRepository<TEntity, TId> : CustomQueryRepository<TEntity>, IReadRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>, new()
{
    protected ReadRepository(DbContext context) : base(context)
    {
    }

    protected string RepositoryTypeName => GetType().FullName ?? GetType().Name;

    public virtual Task<TEntity?> FindById(TId id)
    {
        return Model.AsNoTracking().Where(x => x.Id!.Equals(id)).FirstOrDefaultAsync();
    }

    public virtual Task<bool> Exists(TId id)
    {
        return Task.FromResult(FindById(id).Result is not null);
    }
}
