using System.ComponentModel.DataAnnotations;
using Eudwia.Server.Data.Contracts;
using Eudwia.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eudwia.Server.Data;

public class Payment : IAuditableEntity, ITenantEntity
{
    public Guid Id { get; set; }

    [MaxLength(200)]
    public string Note { get; set; } = string.Empty;

    [Precision(18, 2)]
    public decimal Amount { get; set; }

    public Guid MemberId { get; set; }

    public Member Member { get; set; } = default!;

    public bool IsDeleted { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime AuditCreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditCreatedBy { get; set; } = string.Empty;

    public DateTime AuditModifiedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditModifiedBy { get; set; } = string.Empty;

    public Guid TenantId { get; set; }
}