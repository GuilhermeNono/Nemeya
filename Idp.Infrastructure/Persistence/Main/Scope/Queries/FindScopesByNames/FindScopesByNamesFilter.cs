using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Scope.Queries.FindScopesByNames;

public record FindScopesByNamesFilter(string[] Names) : IFilter;