using Idp.Domain.Annotations;
using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByName;

public record FindScopesByNameFilter([property:IgnoreFilterProperty]string[] Names) : IFilter
{
    public string FormatedNames =>  string.Join(",", Names);
}