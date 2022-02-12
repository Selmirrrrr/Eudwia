using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Eudwia.Server.Data;
using Eudwia.Server.Settings;
using Eudwia.Shared;
using Eudwia.Shared.Features.Authentication.Login;

namespace Eudwia.Server.Features.Authentication.Login;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class LoginEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly SignInManager<Member> _signInManager;

    public LoginEndpoint(UserManager<Member> userManager, JwtSettings jwtSettings, SignInManager<Member> signInManager)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _signInManager = signInManager;
    }

    [HttpPost(Routes.Account.Login)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IList<LoginResult>>> HandleAsync(LoginCommand request, CancellationToken cancellationToken = default)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

        if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

        var user = await _userManager.FindByEmailAsync(request.Email);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, request.Email),
            new("FirstName", user.FirstName),
            new("LastName", user.LastName),
            new("Id", user.Id.ToString()),
            new("Lang", user.Language.ToString())
        };
        
        claims.AddRange((await _userManager.GetRolesAsync(user)).Select(role => new Claim(ClaimTypes.Role, role)).ToList());

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_jwtSettings.ExpiryInDays));

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
