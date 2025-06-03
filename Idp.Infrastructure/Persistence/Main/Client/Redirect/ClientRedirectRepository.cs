using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect;

public class ClientRedirectRepository : CrudRepository<ClientRedirectEntity, Guid>, IClientRedirectRepository
{
    public ClientRedirectRepository(MainContext context) : base(context)
    {
    }
}