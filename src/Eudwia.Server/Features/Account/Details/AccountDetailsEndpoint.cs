using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Shared;
using Eudwia.Shared.Features.Account.Details;

namespace Eudwia.Server.Features.Account.Details;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class AccountDetailsEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public AccountDetailsEndpoint(UserManager<Member> userManager)
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
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        return Ok(details);
    }
}
