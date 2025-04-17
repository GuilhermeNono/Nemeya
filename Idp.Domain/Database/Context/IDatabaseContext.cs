using Idp.Domain.Database.Transaction;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Idp.Domain.Database.Context;

public interface IDatabaseContext : IDatabaseTransaction, IDisposable
{
    DatabaseFacade Database { get; }
}
