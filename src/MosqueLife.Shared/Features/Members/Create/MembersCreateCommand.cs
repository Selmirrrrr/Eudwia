using FluentValidation;
using MosqueLife.Shared.Enums;

namespace MosqueLife.Shared.Features.Members.Create;

public record MembersCreateCommand
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }

    public DateTime? MemberSince { get; set; }

    public string StreetLine1 { get; set; } = string.Empty;

    public string? StreetLine2 { get; set; }

    public string HouseNumber { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public Guid CountryId { get; set; } = Guid.Parse("9bc1f1a9-7696-42e4-89aa-c93800704582"); // CH

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public Language Language { get; set; }
}

public class MembersCreateCommandValidator : AbstractValidator<MembersCreateCommand> 
{
    public MembersCreateCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.MemberSince).NotEmpty();
        RuleFor(x => x.StreetLine1).NotEmpty().MinimumLength(3).MaximumLength(200);
        RuleFor(x => x.StreetLine2).Length(3, 200).When(x => !string.IsNullOrWhiteSpace(x.StreetLine2));
        RuleFor(x => x.HouseNumber).NotEmpty().MinimumLength(1).MaximumLength(10);
        RuleFor(x => x.ZipCode).NotEmpty().MinimumLength(3).MaximumLength(10);
        RuleFor(x => x.City).MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.State).MaximumLength(100);
        RuleFor(x => x.CountryId).NotEmpty();
        RuleFor(x => x.Language).IsInEnum();
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
        RuleFor(x => x.PhoneNumber).Length(9, 50).When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MembersCreateCommand>.CreateWithOptions((MembersCreateCommand)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}