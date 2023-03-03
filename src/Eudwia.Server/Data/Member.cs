using System.ComponentModel.DataAnnotations;
using Eudwia.Server.Data.Contracts;
using Microsoft.AspNetCore.Identity;
using Eudwia.Shared.Enums;

namespace Eudwia.Server.Data;

public class Member : IdentityUser<Guid>, IAuditableEntity, ITenantEntity
{
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? GivenName { get; set; }
    
    [MaxLength(2000)]
    public string? Note { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime MemberSince { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(200)]
    public string StreetLine1 { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? StreetLine2 { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(10)]
    public string HouseNumber { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(10)]
    public string ZipCode { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? State { get; set; } = string.Empty;

    public Guid CountryId { get; set; } = Guid.Parse("20ea933e-023a-4e5b-997e-b9bad3e54cd2");

    public Country Country { get; set; } = default!;

    public Language Language { get; set; }

    public virtual ICollection<Payment> Payments { get; private set; }

    public virtual ICollection<SubscriptionPaid> SubscriptionsPaid { get; private set; }

    public DateTime AuditCreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditCreatedBy { get; set; } = string.Empty;

    public DateTime AuditModifiedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string AuditModifiedBy { get; set; } = string.Empty;

    public Guid TenantId { get; set; }
    
    public bool IsDeleted { get; set; }
    public bool ContactByEMail { get; set; } = true;
    public bool ContactByPhone { get; set; } = true;
    public bool ContactByMail { get; set; } = true;

    public Member(ICollection<Payment> payments, ICollection<SubscriptionPaid> subscriptionsPaid)
    {
        Payments = payments;
        SubscriptionsPaid = subscriptionsPaid;
    }

    public Member()
    {
        Payments = new List<Payment>();
        SubscriptionsPaid = new List<SubscriptionPaid>();
    }
}