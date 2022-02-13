using FluentValidation;

namespace Eudwia.Shared.Features.Members.Security;

public record MembersPasswordUpdateCommand
{
    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}

public class MembersPasswordUpdateCommandValidator : AbstractValidator<MembersPasswordUpdateCommand>
{
    public MembersPasswordUpdateCommandValidator()
    {
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.Password)
            .Equal(x => x.ConfirmPassword)
            .When(x => !string.IsNullOrWhiteSpace(x.Password));
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MembersPasswordUpdateCommand>.CreateWithOptions((MembersPasswordUpdateCommand) model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}