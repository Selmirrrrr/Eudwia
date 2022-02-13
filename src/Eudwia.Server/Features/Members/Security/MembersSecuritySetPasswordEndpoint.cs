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
public class MembersSecuritySetPasswordEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public MembersSecuritySetPasswordEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("members/{memberId:guid}/password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId, [FromBody] MembersSecuritySetPasswordCommand command)
    {
        var member = await _userManager.FindByIdAsync(memberId.ToString());
        
        if (member is null) return NotFound(memberId);

        var token = await _userManager.GeneratePasswordResetTokenAsync(member);
        var result = await _userManager.ResetPasswordAsync(member, token, command.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok();
    }
}