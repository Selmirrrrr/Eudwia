using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eudwia.Shared.Features.Authentication.Register;

public record RegisterModel
{
    [Required]
    [EmailAddress(ErrorMessage = "The value is not valid email address")]
    [Display(Name = "Email")]

    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;


    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class RegisterModelValidator : AbstractValidator<RegisterModel> 
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.Password)
            .Equal(x => x.ConfirmPassword)
            .When(x=>!string.IsNullOrWhiteSpace(x.Password));}
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<RegisterModel>.CreateWithOptions((RegisterModel)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}
