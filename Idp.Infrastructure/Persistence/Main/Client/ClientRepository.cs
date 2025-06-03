using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.Persistence.Main.Client;

public class ClientRepository : CrudRepository<ClientEntity, Guid>, IClientRepository
{
    public ClientRepository(DbContext context) : base(context)
    {
    }
}