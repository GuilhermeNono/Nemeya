using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Client.Scope;

public class ClientScopeRepository : CrudRepository<ClientScopeEntity, Guid>, IClientScopeRepository
{
    public ClientScopeRepository(MainContext context) : base(context)
    {
    }
}