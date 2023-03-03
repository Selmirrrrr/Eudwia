using Eudwia.Shared.Enums;

namespace Eudwia.Shared.Features.Members.Details;

public record MembersDetailsViewModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    
    public string? GivenName { get; set; }
    
    public string? Note { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? MemberSince { get; set; }

    public string StreetLine1 { get; set; } = string.Empty;

    public string? StreetLine2 { get; set; }

    public string HouseNumber { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? State { get; set; } = string.Empty;

    public Guid CountryId { get; set; }
    public string Country { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public Language Language { get; set; }

    public virtual PaymentOverview[] Payments { get; set; } = Array.Empty<PaymentOverview>();

    public virtual MonthsPaidByYear[] MonthsPaidByYears { get; set; } = Array.Empty<MonthsPaidByYear>();
    
    public bool ContactByEMail { get; set; }
    public bool ContactByPhone { get; set; }
    public bool ContactByMail { get; set; }

    public record MonthsPaidByYear
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
    }

    public record PaymentOverview
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}