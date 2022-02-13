namespace Eudwia.Server.Settings;

public class JwtSettings
{
    public const string Position = "Jwt";

    public string SecurityKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpiryInDays { get; set; } = 1;
}