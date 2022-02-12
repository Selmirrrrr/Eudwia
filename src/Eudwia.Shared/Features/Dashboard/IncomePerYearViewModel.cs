using Eudwia.Shared.Enums;

namespace Eudwia.Shared.Features.Dashboard;

public record IncomePerYearViewModel
{
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
}