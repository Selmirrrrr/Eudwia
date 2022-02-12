using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Authentication.Register;

namespace Eudwia.Server.Features.Authentication.Register;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class RegisterEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public RegisterEndpoint(UserManager<Member> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
        
        if (!_roleManager.Roles.Any())
        {
            var lol = await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.SuperAdmin));
            await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
            await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.User));
            await _userManager.AddToRoleAsync(newUser, Roles.SuperAdmin);
        }
        
        if (result.Succeeded) return Ok(new RegisterResult {Successful = true});
        var errors = result.Errors.Select(x => x.Description);

        return BadRequest(new RegisterResult { Successful = false, Errors = errors });

    }
}
