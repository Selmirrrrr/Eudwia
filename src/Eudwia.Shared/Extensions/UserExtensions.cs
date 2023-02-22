using System.Security.Claims;
using Eudwia.Shared.Authorization;

namespace Eudwia.Shared.Extensions;

public static class UserExtensions
{
    public static string Id(this ClaimsPrincipal user) => user.FindFirst(EudwiaClaims.Id)?.Value ?? string.Empty;
    
    public static string FirstName(this ClaimsPrincipal user) => user.FindFirst(EudwiaClaims.FirstName)?.Value ?? string.Empty;

    public static string LastName(this ClaimsPrincipal user) => user.FindFirst(EudwiaClaims.LastName)?.Value ?? string.Empty;

    public static string Email(this ClaimsPrincipal user) => user.Identity?.Name ?? string.Empty;

    public static Guid Tenant(this ClaimsPrincipal user)
    {
        var tenant = user.FindFirst(EudwiaClaims.Tenant)?.Value;
        Guid.TryParse(tenant, out var tenantId);
        return tenantId;
    }

    public static bool IsInRoleAdmin(this ClaimsPrincipal user) => user.IsInRole(Roles.Admin);
    
    public static bool IsInRoleSuperAdmin(this ClaimsPrincipal user) => user.IsInRole(Roles.SuperAdmin);
    
    public static bool IsInRoleUser(this ClaimsPrincipal user) => user.IsInRole(Roles.User);
}
