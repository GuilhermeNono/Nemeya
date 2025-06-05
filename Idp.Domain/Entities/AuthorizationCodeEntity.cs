using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_AuthorizationCodes")]
public class AuthorizationCodeEntity : AuditableEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string CodeChallenge { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public bool IsUsed { get; set; }
    public DateTimeOffset? UsedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }

    public AuthorizationCodeEntity()
    {
    }
}