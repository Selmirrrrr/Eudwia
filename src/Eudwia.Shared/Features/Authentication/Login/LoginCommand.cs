using System.ComponentModel.DataAnnotations;

namespace Eudwia.Shared.Features.Authentication.Login;

public record LoginCommand
{
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; } = string.Empty;
}
