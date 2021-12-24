using System.Security.Claims;

namespace MosqueLife.Shared.Extensions;

public static class UserExtensions
{
    public static string Firstname(this ClaimsPrincipal user) => user.FindFirst("Firstname")?.Value ?? string.Empty;

    public static string Lastname(this ClaimsPrincipal user) => user.FindFirst("Lastname")?.Value ?? string.Empty;

    public static string Email(this ClaimsPrincipal user) => user.Identity?.Name ?? string.Empty;
}
