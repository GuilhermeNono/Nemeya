using Idp.Domain.Enums;

namespace Idp.Domain.Database.Entity.Interfaces;

public interface IAudit
{
    public string Operation { get; }
    public InternalOperation InternalOperation { get; set; }
    public string ChangedBy { get; set; } 
    public DateTimeOffset ChangedAt { get; set; }
}
