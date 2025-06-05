using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_Consents")]
public class ConsentEntity : AuditableEntity<long>
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public DateTimeOffset GrantedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset RevokedAt { get; set; }

    public ConsentEntity()
    {
    }
}