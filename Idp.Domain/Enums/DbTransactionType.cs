namespace Idp.Domain.Enums;

public enum DbTransactionType
{
    NoTransaction = 0,
    ReadCommit = 1,
    ReadUncommitted = 2,
}
