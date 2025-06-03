using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class ClientRedirectEntity : AuditableEntity<Guid>
{
    public string Uri { get; set; } = string.Empty;
    public Guid ClientId { get; set; }

    public ClientRedirectEntity()
    {
    }
}