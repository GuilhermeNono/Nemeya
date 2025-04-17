using Idp.Domain.Database.Entity.Interfaces;

namespace Idp.Domain.Database.Entity;

public abstract class AuditableStatefulEntity<TId> : AuditableEntity<TId>, IStateable
{
    public bool IsActive { get; protected set; } = true;
    public virtual void ChangeActiveStatus(bool newStatus = default) => IsActive = newStatus;
}
