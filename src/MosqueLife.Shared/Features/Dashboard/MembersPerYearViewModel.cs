namespace MosqueLife.Shared.Features.Dashboard;

public record MembersPerYearViewModel
{
    public int Year { get; set; }
    public int Count { get; set; }
}