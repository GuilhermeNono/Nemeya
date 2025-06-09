using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_SigningKeys")]
public class SigningKeyEntity : AuditableEntity<Guid>
{
    public string KeyId { get; set; } = string.Empty;
    public string Algorithm { get; set; } = string.Empty;
    public string PublicJwk { get; set; } = string.Empty;
    public bool CanIssue { get; set; } = true;
    public DateTimeOffset? ExpiredAt { get; set; } = null;
    public DateTimeOffset? GracePeriod { get; set; } = null;
}