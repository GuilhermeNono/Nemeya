using Idp.Domain.Enums;

namespace Idp.Domain.Database.Transaction.Metadata;

public class TransactionMetadata
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public DateTimeOffset StartedAt { get; set; }  = DateTimeOffset.Now;
    public DbTransactionType TransactionType { get; }

    public TransactionMetadata(DbTransactionType transactionType)
    {
        TransactionType = transactionType;
    }
}