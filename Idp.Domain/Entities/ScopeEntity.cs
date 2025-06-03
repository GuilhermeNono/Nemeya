using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

public class ScopeEntity : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ScopeEntity()
    {
    }
}