using System.Net.Mime;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Authentication.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eudwia.Server.Features.Account.Register;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class RegisterEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly ApplicationDbContext _context;

    public RegisterEndpoint(UserManager<Member> userManager, RoleManager<IdentityRole<Guid>> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpPost("account/register")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterResult>> HandleAsync([FromBody] RegisterModel model)
    {
        Guid tenantId;

        if (model.Tenant.Equals("DEMO", StringComparison.InvariantCultureIgnoreCase))
            tenantId = await _context.Tenants.IgnoreQueryFilters().Where(t => t.Name.Equals(model.Tenant)).Select(t => t.TenantId).FirstOrDefaultAsync();
        else if (!await _context.Tenants.IgnoreQueryFilters().AnyAsync(t => t.Name.Equals(model.Tenant)))
            tenantId = (await _context.Tenants.AddAsync(new Tenant {Name = model.Tenant})).Entity.TenantId;
        else
            return BadRequest(new RegisterResult {Successful = false, Errors = new List<string> {$"Un tenant {model.Tenant} existe déjà"}});

        var newUser = new Member
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            MemberSince = DateOnly.FromDateTime(DateTime.UtcNow),
            TenantId = tenantId
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (result.Succeeded)
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.SuperAdmin));
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
                await _roleManager.CreateAsync(new IdentityRole<Guid>(Roles.User));
                await _userManager.AddToRoleAsync(newUser, Roles.SuperAdmin);
            }

            await _userManager.AddToRoleAsync(newUser, Roles.Admin);
            return Ok(new RegisterResult {Successful = true});
        }

        var errors = result.Errors.Select(x => x.Description);

        return BadRequest(new RegisterResult {Successful = false, Errors = errors});
    }
}