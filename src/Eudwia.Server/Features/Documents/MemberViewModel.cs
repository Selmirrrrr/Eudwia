namespace Eudwia.Server.Features.Documents;

public class MemberViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StreetLine1 { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;

    public SubscriptionsPaidViewModel SubscriptionsPaid { get; set; } = new SubscriptionsPaidViewModel
    {
        Year = 2021,
    };
    
}