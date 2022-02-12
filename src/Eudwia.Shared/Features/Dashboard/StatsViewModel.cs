namespace Eudwia.Shared.Features.Dashboard;

public record StatsViewModel
{
    public string TopDonator { get; set; } = string.Empty;
    public int MembersCount { get; set; }
    public int PaidMembersCount { get; set; }
    public decimal TotalRevenue { get; set; }
}