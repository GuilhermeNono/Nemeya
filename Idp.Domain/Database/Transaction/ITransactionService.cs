using Idp.Domain.Database.Transaction.Metadata;
using Idp.Domain.Enums;

namespace Idp.Domain.Database.Transaction;

public interface ITransactionService
{
    bool IsTransactionActive { get; }
    IReadOnlyCollection<TransactionMetadata>? TransactionMetadata { get; }
    Task ExecuteInTransactionContextAsync(Func<Task> action, DbTransactionType transactionType,
        TransactionLogLevel logLevel, CancellationToken cancellationToken, bool forceNewTransaction);
}
