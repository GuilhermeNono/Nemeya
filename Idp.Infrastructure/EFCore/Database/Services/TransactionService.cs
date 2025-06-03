using Idp.Domain.Database.Context;
using Idp.Domain.Database.Transaction;
using Idp.Domain.Database.Transaction.Context;
using Idp.Domain.Database.Transaction.Metadata;
using Idp.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Idp.Infrastructure.EFCore.Database.Services;

public class TransactionService(
    IMainContext mainContext,
    IAuditContext auditContext,
    ILogger<TransactionService> logger)
    : ITransactionService
{
    private readonly Dictionary<int, IDatabaseTransaction?> _transactionContext = [];

    public bool IsTransactionActive => TransactionContext.IsTransactionActive;
    public IReadOnlyCollection<TransactionMetadata>? TransactionMetadata => TransactionContext.Transactions;

    public async Task ExecuteInTransactionContextAsync(Func<Task> action, DbTransactionType transactionType,
        TransactionLogLevel logLevel, CancellationToken cancellationToken, bool forceNewTransaction)
    {
        var nested = TransactionContext.IsTransactionActive && !forceNewTransaction;

        if (nested)
        {
            await action();
            return;
        }

        cancellationToken.ThrowIfCancellationRequested();

        TransactionContext.Push(new TransactionMetadata(transactionType));

        try
        {
            await BeginTransaction(transactionType, cancellationToken);

            SendMessageOfTransactionStatus("|> Beginning transactions\n", logLevel);

            await action();

            await CommitAllDbTransactions(cancellationToken);
            SendMessageOfTransactionStatus("|> Transaction Commited\n", logLevel);
        }
        catch (Exception)
        {
            SendMessageOfTransactionStatus("|> Rollback transaction executed\n", logLevel);

            await RollbackAllDbTransactions(cancellationToken);
            throw;
        }
        finally
        {
            TransactionContext.Pop();
        }
    }

    private void SendMessageOfTransactionStatus(string message,
        TransactionLogLevel logLevel = TransactionLogLevel.None)
    {
        if (logLevel is TransactionLogLevel.None)
            return;

        if (_transactionContext.Count is not 0)
            logger.LogInformation("{Message}", message);
    }

    private async Task BeginTransaction(DbTransactionType transactionType, CancellationToken cancellationToken)
    {
        await ComputeDbTransaction(mainContext, transactionType, cancellationToken);
        await ComputeDbTransaction(auditContext, transactionType, cancellationToken);
    }

    private async Task ComputeDbTransaction(IDatabaseContext context, DbTransactionType transactionType,
        CancellationToken cancellationToken)
    {
        if (!HashKeyExistInTransactionList(context.GetHashCode()))
        {
            await mainContext.BeginTransactionAsync(transactionType, cancellationToken);
            AddDbContext(context);
        }
    }

    private async Task CommitAllDbTransactions(CancellationToken cancellationToken)
    {
        await Task.WhenAll(
            _transactionContext.Select(x => x.Value!.CommitTransactionAsync(cancellationToken)).ToArray());
    }

    private async Task RollbackAllDbTransactions(CancellationToken cancellationToken)
    {
        foreach (var (provider, transaction) in _transactionContext)
        {
            if (transaction is null) continue;

            await transaction.RollbackTransactionAsync(cancellationToken);
            _transactionContext.Remove(provider);
        }
    }

    private void AddDbContext(IDatabaseContext context) => _transactionContext.Add(context.GetHashCode(), context);

    private bool HashKeyExistInTransactionList(int hashKey) => _transactionContext.ContainsKey(hashKey);
}