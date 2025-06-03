using Idp.Domain.Database.Repository;
using Idp.Domain.Entities;

namespace Idp.Domain.Repositories;

public interface IClientRedirectRepository : ICrudRepository<ClientRedirectEntity, Guid>
{
    
}