using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_LoginAttempts")]
public class LoginAttemptEntity : Entity<long>
{
    public Guid UserId { get; set; }
    public string IpAddress { get; set; } = string.Empty;
    public DateTimeOffset AttemptAt { get; set; }
    public string UserAgent { get; set; } = string.Empty;
    public bool ItWasSuccessful { get; set; }

    public LoginAttemptEntity()
    {
    }
}