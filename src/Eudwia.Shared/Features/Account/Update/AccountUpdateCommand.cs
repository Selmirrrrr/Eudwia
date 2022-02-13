using FluentValidation;

namespace Eudwia.Shared.Features.Account.Update;

public record AccountUpdateCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
}

public class MembersUpdateCommandValidator : AbstractValidator<AccountUpdateCommand>
{
    public MembersUpdateCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).MaximumLength(100);
        //RuleFor(x => x.Password).Matches(new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$"))
        //    .WithMessage("Le mot de passe doit contenir au moins 8 caractères.");
        //RuleFor(x => x.Password).Matches("");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AccountUpdateCommand>.CreateWithOptions((AccountUpdateCommand) model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}