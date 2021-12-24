using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Account.UpdateAccount;

namespace MosqueLife.Server.Features.Account.Update;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class AccountUpdateEndpoint : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountUpdateEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(Routes.Account.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<IActionResult> Handle(Guid id, [FromBody] AccountUpdateCommand accountUpdate)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
        {
            return BadRequest("error");
        }

        user.Firstname = accountUpdate.Firstname;
        user.Lastname = accountUpdate.Lastname;

        await _userManager.UpdateAsync(user);
        return Ok();
    }
}
