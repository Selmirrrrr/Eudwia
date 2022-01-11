using MosqueLife.Shared.Enums;

namespace MosqueLife.Shared.Features.Dashboard;

public record IncomePerYearViewModel
{
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
}