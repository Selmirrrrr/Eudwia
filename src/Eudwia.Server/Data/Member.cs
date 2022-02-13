using System.ComponentModel.DataAnnotations;
using Eudwia.Server.Data.Contracts;
using Microsoft.AspNetCore.Identity;
using Eudwia.Shared.Enums;

namespace Eudwia.Server.Data;

public class Member : IdentityUser<Guid>, IAuditableEntity
{
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    public DateOnly MemberSince { get; set; }

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
    public string AuditCreatedBy { get; set; } = string.Empty;
    public DateTime AuditModifiedAt { get; set; } = DateTime.UtcNow;
    public string AuditModifiedBy { get; set; } = string.Empty;

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
