namespace MosqueLife.Shared.Features.Dashboard;

public record StatsViewModel
{
    public int AverageAge { get; set; }
    public int MembersCount { get; set; }
    public int PaidMembersCount { get; set; }
    public decimal TotalRevenue { get; set; }
}