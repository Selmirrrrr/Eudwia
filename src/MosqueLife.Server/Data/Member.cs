using System.ComponentModel.DataAnnotations;

namespace MosqueLife.Server.Data;

public class Member
{
    public Guid Id { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Lastname { get; set; } = string.Empty;

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

    public Guid StateId { get; set; }

    public State State { get; set; } = default!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public Language Language { get; set; }

    public virtual ICollection<Payment> Payments { get; private set; }

    public virtual ICollection<SubscriptionPaid> SubscriptionsPaid { get; private set; }

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
