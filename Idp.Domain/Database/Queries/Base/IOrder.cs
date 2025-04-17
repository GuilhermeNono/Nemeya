using System.Linq.Expressions;
using Idp.Domain.Enums;

namespace Idp.Domain.Database.Queries.Base;

public interface IOrder<TResult>
{
    public string Column { get; }
    public Sort Sort { get; }
    protected string By<TProperty>(Expression<Func<TResult, TProperty>> expression, Sort sort);
    protected string By(string customOrder, Sort sort);
}
