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
[Authorize(Policy = Policies.IsSuperAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MembersSecurityRemove : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public MembersSecurityRemove(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("members/{memberId:guid}/remove")]
    [ProducesResponseType(typeof(MembersSecurityGetRolesViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Members.IgnoreQueryFilters()
            .FirstAsync(u => u.Id == memberId, cancellationToken);

        if (user.IsDeleted)
        {
            user.IsDeleted = false;
        }
        else
        {
            _dbContext.Remove(user);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}