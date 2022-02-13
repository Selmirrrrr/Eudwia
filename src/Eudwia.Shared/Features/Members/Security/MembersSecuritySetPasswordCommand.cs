using FluentValidation;

namespace Eudwia.Shared.Features.Members.Security;

public record MembersSecuritySetPasswordCommand
{
    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}

public class MembersSecuritySetPasswordCommandValidator : AbstractValidator<MembersSecuritySetPasswordCommand>
{
    public MembersSecuritySetPasswordCommandValidator()
    {
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .When(x => !string.IsNullOrWhiteSpace(x.Password));
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MembersSecuritySetPasswordCommand>.CreateWithOptions((MembersSecuritySetPasswordCommand) model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}