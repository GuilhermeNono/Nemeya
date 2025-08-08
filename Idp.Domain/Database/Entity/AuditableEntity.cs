﻿using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity.Interfaces;
using Idp.Domain.Enums;
using Idp.Domain.Enums.Smart;
using Idp.Domain.Helpers;

namespace Idp.Domain.Database.Entity;

public abstract class AuditableEntity<TId> : Entity<TId>, IAudit
{
    public string Operation { get; protected set; } = OperationHelper.Create;
    
    [NotMapped]
    public InternalOperation InternalOperation
    {
        get => Enum.Parse<InternalOperation>(Operation, true);
        set => Operation = value.ToString();
    }
    public string ChangedBy { get; set; } = DefaultUserOperation.System;
    public DateTimeOffset ChangedAt { get; set; }
}
