﻿using System.ComponentModel.DataAnnotations.Schema;
using Idp.Domain.Database.Entity;

namespace Idp.Domain.Entities;

[Table("Ath_Tokens")]
public class TokenEntity : AuditableEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; } = string.Empty;

    public TokenEntity()
    {
    }
}