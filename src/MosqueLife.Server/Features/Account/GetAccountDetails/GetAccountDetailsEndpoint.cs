using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Shared;
using System.Net.Mime;
using MosqueLife.Shared.Features.Account.GetAccountDetails;

namespace MosqueLife.Server.Features.Account.GetAccountDetails;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class GetAccountDetailsEndpoint : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAccountDetailsEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet(Routes.Account.Get)]
    [ProducesResponseType(typeof(GetAccountDetailsResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAccountDetailsResult>> Handle(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return NotFound("user not found");
        }

        var details = new GetAccountDetailsResult
        {
            Id = user.Id,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
        };

        return Ok(details);
    }
}
