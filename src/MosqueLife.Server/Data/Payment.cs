namespace MosqueLife.Server.Data;

public class Payment
{
    public Guid Id { get; set; }

    public string Note { get; set; } = string.Empty;

    public Guid MemberId { get; set; }

    public Member Member { get; set; } = default!;

    public PaymentType PaymentType { get; set; }
}
