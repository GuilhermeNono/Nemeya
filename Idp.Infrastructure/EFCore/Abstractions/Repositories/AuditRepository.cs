﻿using Idp.CrossCutting.Exceptions.Http.UnprocessableEntity.Entity;
using Idp.CrossCutting.Messages;
using Idp.Domain.Database.Entity.Interfaces;
using Idp.Domain.Database.Repository;
using Idp.Domain.Enums;
using Idp.Infrastructure.EFCore.Database.Context;

namespace Idp.Infrastructure.EFCore.Abstractions.Repositories;

public abstract class AuditRepository<TEntity, TId>(AuditContext context)
    : CrudRepository<TEntity, TId>(context), IAuditRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>, new()
{
    public override async Task<int> Delete(TEntity entity, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);

        UpdateAuditOfEntity(entity, InternalOperation.D);
        
        return await Context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<int> Delete(TId id, string userWhoDeleted, CancellationToken cancellationToken)
    {
        var entity = await FindById(id) ?? 
                     throw new EntityNotFound(ErrorMessage.Exception.EntityNotFound(nameof(TEntity)));

        return await Delete(entity, userWhoDeleted, cancellationToken);
    }
    
    public async Task<int> Delete(TEntity entity, string userWhoDeleted, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);

        UpdateAuditOfEntity(entity, InternalOperation.D, userWhoDeleted);
        
        return await Context.SaveChangesAsync(cancellationToken);
    }
    
    public override async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);
        
        UpdateAuditOfEntity(entity, InternalOperation.U);
        
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public override async Task<IEnumerable<TEntity>> Update(IList<TEntity> entities, string userWhoUpdated, CancellationToken cancellationToken)
    {
        await Model.AddRangeAsync(entities, cancellationToken);

        foreach (var entity in entities)
            UpdateAuditOfEntity(entity, InternalOperation.U);
        
        await Context.SaveChangesAsync(cancellationToken);
        
        return entities;
    }

    public override async Task<TEntity> Update(TEntity entity, string userWhoUpdated, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);
        
        UpdateAuditOfEntity(entity, InternalOperation.U, userWhoUpdated);
        
        await Context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    public override async Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);

        UpdateAuditOfEntity(entity, InternalOperation.C);
        
        await Context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public override async Task<TEntity> Add(TEntity entity, string userWhoAdded, CancellationToken cancellationToken)
    {
        await Model.AddAsync(entity, cancellationToken);

        UpdateAuditOfEntity(entity, InternalOperation.C, userWhoAdded);
        
        await Context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
