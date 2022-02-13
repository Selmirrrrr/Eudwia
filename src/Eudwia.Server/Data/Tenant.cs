using System.ComponentModel.DataAnnotations;
using Eudwia.Server.Data.Contracts;

namespace Eudwia.Server.Data;

public class Tenant : ITenantEntity, IAuditableEntity
{
    public Guid TenantId { get; set; }

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public DateTime AuditCreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditCreatedBy { get; set; } = string.Empty;

    public DateTime AuditModifiedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditModifiedBy { get; set; } = string.Empty;
}