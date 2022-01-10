using MosqueLife.Shared.Enums;

namespace MosqueLife.Shared.Features.Members.Payments;

public record MembersPaymentViewModel
{
    public Guid Id { get; init; }
    
    public string Note { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime PaymentDate { get; set; }
}
