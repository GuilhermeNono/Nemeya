using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.Client.Queries.GetClientById;
using Idp.Infrastructure.Persistence.Main.Client.Queries.HasNoClients;
using Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.FindByClientId;

namespace Idp.Infrastructure.Persistence.Main.Client;

public class ClientRepository(MainContext context) : CrudRepository<ClientEntity, Guid>(context), IClientRepository
{
    public Task<bool> HasAtLeastOneClient() =>
        QuerySingleValue(new HasAtLeastOneClientQuery());

    public Task<bool> ExistsByClientId(string clientId) =>
        QuerySingleValue(new ExistsByClientIdQuery(new ExistsByClientIdFilter(clientId)));

    public Task<ClientEntity?> FindByClientId(string clientId) =>
        QuerySingle(new FindByClientIdQuery(new FindByClientIdFilter(clientId)));
}