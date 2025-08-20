using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.FindByClientId;

public record FindByClientIdFilter(string ClientId) : IFilter;