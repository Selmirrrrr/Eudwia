using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Authentication.Register;

namespace MosqueLife.Server.Features.Authentication.Register;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class RegisterEndpoint : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(Routes.Account.Register)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterResult>> HandleAsync([FromBody] RegisterModel model)
    {
        var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, Firstname = model.Firstname, Lastname = model.Lastname };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);

            return BadRequest(new RegisterResult { Successful = false, Errors = errors });
        }

        return Ok(new RegisterResult { Successful = true });
    }
}
