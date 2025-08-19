using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.Client.Queries.HasNoClients;

namespace Idp.Infrastructure.Persistence.Main.Client;

public class ClientRepository(MainContext context) : CrudRepository<ClientEntity, Guid>(context), IClientRepository
{
    public Task<bool> HasAtLeastOneClient() => QuerySingleValue(new HasAtLeastOneClientQuery());
}
