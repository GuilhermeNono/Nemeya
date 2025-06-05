using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_ConsentScopes")]
public class ConsentScopeEntity : Entity<long>
{
    public long ConsentId { get; set; }
    public int ScopeId { get; set; }
    public DateTimeOffset ConsentedAt { get; set; }
}