using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.Persistence.Main.Consent;

public class ConsentRepository : CrudRepository<ConsentEntity, long>, IConsentRepository
{
    public ConsentRepository(MainContext context) : base(context)
    {
    }
}