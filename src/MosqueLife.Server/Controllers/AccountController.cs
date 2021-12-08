using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MosqueLife.Server.Data;
using MosqueLife.Shared.Models.Authentication;
using MosqueLife.Shared.Models.Personal;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace MosqueLife.Server.Controllers;

[Route("api/[controller]")]
[ApiController]

[Produces(MediaTypeNames.Application.Json)]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _signInManager = signInManager;
    }

    [HttpPost("Register")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RegisterResult>> Post([FromBody] RegisterModel model)
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

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<LoginResult>> Login([FromBody] LoginModel login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

        if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

        var user = await _userManager.FindByEmailAsync(login.Email);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Email),
            new Claim("Firstname",user.Firstname?? ""),
            new Claim("Lastname",user.Lastname?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

        var token = new JwtSecurityToken(
            _configuration["JwtIssuer"],
            _configuration["JwtAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    [HttpPatch("patch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<IActionResult> Patch([FromBody] UpdateUserModel update)
    {
        var user = await _userManager.FindByEmailAsync(update.Email);
        if (user is null)
        {
            return BadRequest("error");
        }

        user.Firstname = update.Firstname;
        user.Lastname = update.Lastname;

        await _userManager.UpdateAsync(user);
        return Ok();
    }



    [Authorize]
    [HttpGet("userdetails/{email}")]
    [ProducesResponseType(typeof(UserDetails), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetails>> UserDetails(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return NotFound("user not found");
        }

        var details = new UserDetails
        {
            Id = user.Id,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
        };

        return Ok(details);
    }
}
