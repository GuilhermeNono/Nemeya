using Idp.Domain.Database.Transaction.Metadata;

namespace Idp.Domain.Database.Transaction.Context;

public static class TransactionContext
{
    private static readonly AsyncLocal<Stack<TransactionMetadata>> TransactionStack = new();
    
    public static IReadOnlyCollection<TransactionMetadata>? Transactions => TransactionStack.Value?.ToArray().AsReadOnly();

    public static TransactionMetadata? Current => TransactionStack.Value?.Peek();

    public static bool IsTransactionActive => TransactionStack.Value?.Count > 0;

    public static void Push(TransactionMetadata transactionMetadata)
    {
        TransactionStack.Value ??= new Stack<TransactionMetadata>();

        TransactionStack.Value.Push(transactionMetadata);
    }

    public static void Pop() => TransactionStack.Value?.Pop();
    public static void Clear() => TransactionStack.Value?.Clear();
}