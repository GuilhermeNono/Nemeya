using Idp.Domain.Annotations;
using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByName;

public record FindScopesByNameFilter(string Name) : IFilter
{
}