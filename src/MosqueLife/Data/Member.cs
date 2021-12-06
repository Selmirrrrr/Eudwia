using System.ComponentModel.DataAnnotations;

namespace MosqueLife.Data
{
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

        public DateOnly? MemberSince { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string StreetLine1 { get; private init; } = string.Empty;

        [MaxLength(200)]
        public string? StreetLine2 { get; private init; }

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public string HouseNumber { get; private init; } = string.Empty;

        [Range(1000, 999999)]
        public int ZipCode { get; private init; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string City { get; private init; } = string.Empty;

        public Guid StateId { get; set; }
        public State State { get; set; }

        public virtual ICollection<SubscriptionPaid> Subscriptions { get; private set; }

        public Member()
        {
            Subscriptions = new List<SubscriptionPaid>();
        }
    }
}
