namespace MosqueLife.Shared.Features.Dashboard;

public record StatsViewModel
{
    public double AverageAge { get; set; }
    public int MembersCount { get; set; }
    public int PaidMembersCount { get; set; }
    public decimal TotalRevenue { get; set; }
}