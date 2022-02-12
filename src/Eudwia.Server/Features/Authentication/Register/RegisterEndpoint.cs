using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Shared;
using Eudwia.Shared.Features.Authentication.Register;

namespace Eudwia.Server.Features.Authentication.Register;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class RegisterEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public RegisterEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(Routes.Account.Register)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterResult>> HandleAsync([FromBody] RegisterModel model)
    {
        var newUser = new Member 
        { 
            UserName = model.Email, 
            Email = model.Email, 
            FirstName = model.FirstName, 
            LastName = model.LastName
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description);

            return BadRequest(new RegisterResult { Successful = false, Errors = errors });
        }

        return Ok(new RegisterResult { Successful = true });
    }
}
