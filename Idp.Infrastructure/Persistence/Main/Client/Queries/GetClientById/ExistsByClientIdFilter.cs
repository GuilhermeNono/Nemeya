using Idp.Domain.Database.Queries.Base;

namespace Idp.Infrastructure.Persistence.Main.Client.Queries.GetClientById;

public record ExistsByClientIdFilter(string ClientId) : IFilter;