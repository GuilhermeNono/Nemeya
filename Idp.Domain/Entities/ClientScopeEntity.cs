using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class ClientScopeEntity : AuditableEntity<Guid>
{
    public int ScopeId { get; set; }
    public Guid ClientId { get; set; }

    public ClientScopeEntity()
    {
    }
}