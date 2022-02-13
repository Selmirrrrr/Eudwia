using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Security;
using Microsoft.AspNetCore.Identity;

namespace Eudwia.Server.Features.Members.Security;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersSecurityGetRolesEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public MemebersSecurityGetRolesEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("members/{memberId:guid}/roles")]
    [ProducesResponseType(typeof(MembersSecurityGetRolesViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId)
    {
        var member = await _userManager.FindByIdAsync(memberId.ToString());
        if (member is null) return NotFound(memberId);

        var isAdmin = await _userManager.IsInRoleAsync(member, Roles.SuperAdmin) ||
                      await _userManager.IsInRoleAsync(member, Roles.Admin);
        var isUser = await _userManager.IsInRoleAsync(member, Roles.User);;
        
        return Ok(new MembersSecurityGetRolesViewModel { IsAdmin = isAdmin, IsUser = isUser});
    }
}