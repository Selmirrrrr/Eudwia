using Microsoft.AspNetCore.Authorization;

namespace Eudwia.Shared.Authorization;

public static class Policies
{
    public const string IsSuperAdmin = "IsSuperAdmin";
    public const string IsAdmin = "IsAdmin";
    public const string IsUser = "IsUser";
    public const string IsCurrentdUser = "IsCurrentUser";
    
    public static AuthorizationPolicy IsSuperAdminPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
            .RequireRole(Roles.SuperAdmin)
            .Build();
    }
    
    public static AuthorizationPolicy IsAdminPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
            .RequireRole(Roles.Admin, Roles.SuperAdmin)
            .Build();
    }
    
    public static AuthorizationPolicy IsUserPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
            .RequireRole(Roles.User,Roles.Admin, Roles.SuperAdmin)
            .Build();
    }
}