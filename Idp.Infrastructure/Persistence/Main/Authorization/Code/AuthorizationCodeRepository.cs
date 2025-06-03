using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Authorization.Code;

public class AuthorizationCodeRepository : CrudRepository<AuthorizationCodeEntity, Guid>, IAuthorizationCodeRepository
{
    public AuthorizationCodeRepository(MainContext context) : base(context)
    {
    }
}