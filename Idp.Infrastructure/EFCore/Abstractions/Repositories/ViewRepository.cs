using Idp.Domain.Database.Entity.Interfaces;
using Idp.Domain.Database.Repository;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.EFCore.Abstractions.Repositories;

public abstract class ViewRepository<TEntity> : CustomQueryRepository<TEntity>, IViewRepository<TEntity>
    where TEntity : class, IEntityView, new()
{
    protected ViewRepository(DbContext context) : base(context)
    {
    }

    public Task<IAsyncEnumerable<TEntity>> FindAsync()
    {
        return Task.FromResult(Model.AsNoTracking().AsAsyncEnumerable());
    }
}
