using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class TokenEntity : AuditableEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; } = string.Empty;

    public TokenEntity()
    {
    }
}