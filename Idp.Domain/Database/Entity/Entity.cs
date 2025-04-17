using Idp.Domain.Database.Entity.Interfaces;

namespace Idp.Domain.Database.Entity;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId? Id { get; init; }
}
