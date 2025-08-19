using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.IsValidRedirect;

public record IsValidRedirectFilter(Guid ClientId, string RedirectUri) : IFilter
{
}