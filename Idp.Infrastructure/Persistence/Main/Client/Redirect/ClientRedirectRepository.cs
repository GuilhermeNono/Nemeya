using Idp.Domain.Entities;
using Idp.Domain.Repositories;
using Idp.Infrastructure.EFCore.Abstractions.Repositories;
using Idp.Infrastructure.EFCore.Database.Context;
using Idp.Infrastructure.Persistence.Main.Client.Redirect.Queries.IsValidRedirect;

namespace Idp.Infrastructure.Persistence.Main.Client.Redirect;

public class ClientRedirectRepository(MainContext context)
    : CrudRepository<ClientRedirectEntity, Guid>(context), IClientRedirectRepository
{
    public Task<bool> IsValidRedirect(Guid clientId, string requestRedirectUri) =>
        QuerySingleValue(new IsValidRedirectQuery(new IsValidRedirectFilter(clientId, requestRedirectUri)));
}