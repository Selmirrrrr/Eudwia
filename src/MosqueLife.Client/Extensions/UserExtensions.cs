using System.Security.Claims;

namespace MosqueLife.Client.Extensions;

public static class UserExtensions
{
    public static string Id(this ClaimsPrincipal user) => user.FindFirst("Id")?.Value ?? string.Empty;
    
    public static string FirstName(this ClaimsPrincipal user) => user.FindFirst("FirstName")?.Value ?? string.Empty;

    public static string LastName(this ClaimsPrincipal user) => user.FindFirst("LastName")?.Value ?? string.Empty;

    public static string Email(this ClaimsPrincipal user) => user.Identity?.Name ?? string.Empty;
}
