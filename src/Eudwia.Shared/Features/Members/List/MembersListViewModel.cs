namespace Eudwia.Shared.Features.Members.List;

public record MembersListViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime MemberSince { get; set; }
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

    public int MonthsPaid => this.GetType()
                                 .GetProperties()
                                 .Where(x => x.PropertyType == typeof(bool))
                                 .Count(x => x.GetValue(this) as bool? == true);
}