using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Token;

public class TokenRepository : CrudRepository<TokenEntity, Guid>, ITokenRepository
{
    public TokenRepository(MainContext context) : base(context)
    {
    }
}