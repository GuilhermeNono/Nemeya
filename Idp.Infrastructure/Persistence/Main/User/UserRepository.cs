using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.Persistence.Main.User;

public class UserRepository : CrudRepository<UserEntity, Guid>, IUserRepository
{
    public UserRepository(MainContext context) : base(context)
    {
    }
}