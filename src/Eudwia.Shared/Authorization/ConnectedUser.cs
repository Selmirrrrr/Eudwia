using Eudwia.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Eudwia.Shared.Authorization;

public class ConnectedUserHandler : AuthorizationHandler<ConnectedUserRequirement, Guid>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ConnectedUserRequirement requirement, Guid memberId)
    {
        if (string.Equals(context.User.Id(), memberId.ToString(), StringComparison.InvariantCultureIgnoreCase)) 
            context.Succeed(requirement);

        if (context.User.IsInRole(Roles.Admin) || context.User.IsInRole(Roles.SuperAdmin)) 
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}

public class ConnectedUserRequirement : IAuthorizationRequirement
{
}