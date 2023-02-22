using System.ComponentModel.DataAnnotations;
using Eudwia.Server.Data.Contracts;

namespace Eudwia.Server.Data;

public class SubscriptionPaid : IAuditableEntity, ITenantEntity
{
    public int Year { get; set; }
    public bool January { get; set; }
    public bool February { get; set; }
    public bool March { get; set; }
    public bool April { get; set; }
    public bool May { get; set; }
    public bool June { get; set; }
    public bool July { get; set; }
    public bool August { get; set; }
    public bool September { get; set; }
    public bool October { get; set; }
    public bool November { get; set; }
    public bool December { get; set; }
    public Guid MemberId { get; set; }
    public DateTime AuditCreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditCreatedBy { get; set; } = string.Empty;

    public DateTime AuditModifiedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditModifiedBy { get; set; } = string.Empty;

    public Guid TenantId { get; set; }
    
    public bool IsDeleted { get; set; }
}