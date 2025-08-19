using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ppl_People")]
public class PersonEntity : AuditableEntity<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string NormalizedDocument { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }

    public PersonEntity()
    {
    }
}