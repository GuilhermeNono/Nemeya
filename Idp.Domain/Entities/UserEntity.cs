using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class UserEntity : AuditableEntity<Guid>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool HasMfa { get; set; }

    public UserEntity()
    {
    }
}