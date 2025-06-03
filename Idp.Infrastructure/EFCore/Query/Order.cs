using System.Linq.Expressions;
using Idp.Domain.Database.Queries.Base;
using Idp.Domain.Enums;

namespace Idp.Infrastructure.EFCore.Query;

public sealed class Order<TResult> : IOrder<TResult>
{
    public string Column { get; private set; } = string.Empty;
    public Sort Sort { get; private set; } = Sort.Asc;
    public string By<TProperty>(Expression<Func<TResult, TProperty>> expression, Sort sort)
    {
        Sort = sort;
        return Column = ClassProperty.PropertyName(expression);
    }
    
    public string By(string customOrder, Sort sort)
    {
        Sort = sort;
        return Column = customOrder;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Order<TResult> order)
            return false;

        return order.GetType().GUID == GetType().GUID && Equals(order);
    }

    private bool Equals(IOrder<TResult> other)
    {
        return Column == other.Column && Sort == other.Sort;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Column, (int)Sort);
    }
}
