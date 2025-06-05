using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_Clients")]
public class ClientEntity : AuditableEntity<Guid>
{
    public string Name { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;

    public ClientEntity()
    {
    }
}