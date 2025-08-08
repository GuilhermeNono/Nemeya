using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.Persistence.Main.Client;

public class ClientRepository(MainContext context) : CrudRepository<ClientEntity, Guid>(context), IClientRepository;