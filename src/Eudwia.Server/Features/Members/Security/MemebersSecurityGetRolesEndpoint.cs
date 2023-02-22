using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eudwia.Server.Features.Members.Security;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersSecurityGetRolesEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public MemebersSecurityGetRolesEndpoint(UserManager<Member> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
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
        var isUser = await _userManager.IsInRoleAsync(member, Roles.User);

        var deleted = await _dbContext.Users.IgnoreQueryFilters()
            .Where(u => u.Id == memberId)
            .Select(u => u.IsDeleted)
            .FirstAsync();

        return Ok(new MembersSecurityGetRolesViewModel {IsAdmin = isAdmin, IsUser = isUser, IsDeleted = deleted});
    }
}