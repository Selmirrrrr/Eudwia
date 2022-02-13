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
public class MemebersSecurityUpdateRolesEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public MemebersSecurityUpdateRolesEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("members/{memberId:guid}/roles/{role}")]
    [ProducesResponseType(typeof(MembersSecurityGetRolesViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId, [FromRoute] string role, [FromBody] bool value)
    {
        var member = await _userManager.FindByIdAsync(memberId.ToString());

        if (member is null) return NotFound(memberId);

        IdentityResult result;

        if (value)
            result = await _userManager.AddToRoleAsync(member, role);
        else
            result = await _userManager.RemoveFromRoleAsync(member, role);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok();
    }
}