namespace Eudwia.Shared.Features.Authentication.Login;

public record LoginResult : LoginCommand
{
    public bool Successful { get; set; }
    public string Error { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}