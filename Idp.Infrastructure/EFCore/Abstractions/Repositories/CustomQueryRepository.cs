﻿using Idp.Domain.Database.Queries.Base;
using Idp.Infrastructure.EFCore.Query.CustomQuery.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Idp.Infrastructure.EFCore.Abstractions.Repositories;

public abstract class CustomQueryRepository<TEntity> : EfContext<TEntity> where TEntity : class
{
    protected CustomQueryRepository(DbContext context) : base(context)
    {
    }

    protected Task<TResult?> QuerySingle<TFilter, TResult>(IQuery<TResult, TFilter> query)
        where TFilter : IFilter
    {
        return Task.FromResult(Context.Database.SqlQueryRaw<TResult>(query.Query, query.Parameters()!).AsEnumerable()
            .FirstOrDefault());
    }

    protected Task<TResult?> QuerySingle<TResult>(IQuery<TResult> query) where TResult : class 
    {
        return Task.FromResult(Context.Database.SqlQueryRaw<TResult>(query.Query).AsNoTracking().AsEnumerable()
            .FirstOrDefault());
    }
    
    protected Task<TResult> QueryValue<TResult>(IQuery<TResult> query) where TResult : struct
    {
        return Task.FromResult(Context.Database.SqlQueryRaw<TResult>(query.Query).AsEnumerable().FirstOrDefault());
    }

    protected IEnumerable<TResult> Query<TFilter, TResult>(IQuery<TResult, TFilter> query)
        where TFilter : IFilter where TResult : class
    {
        return Context.Database.SqlQueryRaw<TResult>(query.Query, query.Parameters()!).AsNoTracking().AsEnumerable();
    }

    protected IEnumerable<TResult> Query<TResult>(IQuery<TResult> query) where TResult : class
    {
        return Context.Database.SqlQueryRaw<TResult>(query.Query).AsNoTracking().AsEnumerable();
    }

    protected TResult CountQueryPaged<TResult>(IQuery<TResult> query) where TResult : class
    {
        return Context.Database.SqlQueryRaw<TResult>(query.Count).AsNoTracking().First();
    }

    protected TResult CountQueryPaged<TFilter, TResult>(IQuery<TResult, TFilter> query)
        where TResult : class where TFilter : IFilter
    {
        return Context.Database.SqlQueryRaw<TResult>(query.Count, query.Parameters()!).AsNoTracking()
            .SingleOrDefault()!;
    }
}