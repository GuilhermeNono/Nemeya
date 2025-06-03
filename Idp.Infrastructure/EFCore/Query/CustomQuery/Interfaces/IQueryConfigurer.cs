namespace Idp.Infrastructure.EFCore.Query.CustomQuery.Interfaces;

public interface IQueryConfigurer<TResult> 
{
    public string Count {get;}

    public string Query {get;}

}