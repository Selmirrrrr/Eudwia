using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Account.GetAccountDetails;

namespace MosqueLife.Server.Features.Account.Details;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class AccountDetailsEndpoint : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountDetailsEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet(Routes.Account.Get)]
    [ProducesResponseType(typeof(AccountDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountDetailsViewModel>> Handle(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user is null)
        {
            return NotFound("user not found");
        }

        var details = new AccountDetailsViewModel
        {
            Id = user.Id,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
        };

        return Ok(details);
    }
}
