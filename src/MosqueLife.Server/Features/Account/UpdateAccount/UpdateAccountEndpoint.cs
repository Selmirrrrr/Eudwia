using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Shared;
using MosqueLife.Shared.Models.Personal;
using System.Net.Mime;

namespace MosqueLife.Server.Features.Account.GetAccountDetails;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class UpdateAccountEndpoint : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UpdateAccountEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(Routes.Account.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<IActionResult> Handle(string email, [FromBody] UpdateAccountCommand update)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return BadRequest("error");
        }

        user.Firstname = update.Firstname;
        user.Lastname = update.Lastname;

        await _userManager.UpdateAsync(user);
        return Ok();
    }
}
