using FluentValidation;
using MosqueLife.Shared.Enums;

namespace MosqueLife.Shared.Features.Members.Payments;

public record MembersAddPaymentCommand
{
    public string Note { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime? PaymentDate { get; set; }
}

public class MembersAddPaymentCommandValidator : AbstractValidator<MembersAddPaymentCommand> 
{
    public MembersAddPaymentCommandValidator()
    {
        RuleFor(x => x.Note).NotEmpty().MinimumLength(3).MaximumLength(200);
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.PaymentType).IsInEnum();
        RuleFor(x => x.PaymentDate).NotNull().LessThanOrEqualTo(DateTime.Now).GreaterThan(new DateTime(2000, 1, 1));
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MembersAddPaymentCommand>.CreateWithOptions((MembersAddPaymentCommand)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}