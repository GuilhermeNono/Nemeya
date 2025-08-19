using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_Users")]
public class UserEntity : AuditableStatefulEntity<Guid>
{
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTimeOffset LastLoginAt { get; set; }
    public bool HasMfa { get; set; }

    public UserEntity()
    {
    }
}