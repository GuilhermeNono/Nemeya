using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Login.Attempt;

public class LoginAttemptRepository : CrudRepository<LoginAttemptEntity, long>, ILoginAttemptRepository
{
    public LoginAttemptRepository(MainContext context) : base(context)
    {
    }
}