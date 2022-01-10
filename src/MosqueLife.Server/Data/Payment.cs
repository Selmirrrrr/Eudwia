using MosqueLife.Shared.Enums;

namespace MosqueLife.Server.Data;

public class Payment
{
    public Guid Id { get; set; }

    public string Note { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public Guid MemberId { get; set; }

    public Member Member { get; set; } = default!;
    
    public bool IsDeleted { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime PaymentDate { get; set; }
}
