using Idp.Domain.Database.Repository;
using Idp.Domain.Entities;

namespace Idp.Domain.Repositories;

public interface IClientRepository : ICrudRepository<ClientEntity, Guid>
{
    Task<bool> HasAtLeastOneClient();
}