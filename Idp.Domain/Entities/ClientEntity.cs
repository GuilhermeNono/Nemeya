using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class ClientEntity : AuditableEntity<Guid>
{
    public string ClientId { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;

    public ClientEntity()
    {
    }
}