using System.Text;
using Idp.CrossCutting.Exceptions.Http.Internal;

namespace Idp.Infrastructure.EFCore.Query.CustomQuery.Structs;

public readonly struct SqlQueryValidator
{
    private readonly ReadOnlyMemory<char> _queryMemory;
    private ReadOnlySpan<char> QuerySpan => _queryMemory.Span;

    private SqlQueryValidator(StringBuilder query)
    {
        _queryMemory = query.ToString().AsMemory();
    }

    public void Validate()
    {
        if (IsUsingQueryOrderingInsteadOfInternalOrderBy())
            throw new ExternalOrderWithInternalPaginationException();
    }

    #region | Validations |

    private bool IsUsingQueryOrderingInsteadOfInternalOrderBy() =>
        QuerySpan.IndexOf("order by", StringComparison.OrdinalIgnoreCase) >= 0;

    #endregion

    public static SqlQueryValidator WithQuery(StringBuilder query) => new(query);
    
    public static implicit operator string(SqlQueryValidator validator) => validator._queryMemory.ToString();
}