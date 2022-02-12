using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Create;

namespace Eudwia.Server.Features.Members.Create;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersCreateEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly UserManager<Member> _userManager;

    public MembersCreateEndpoint(ApplicationDbContext applicationDbContext, UserManager<Member> userManager)
    {
        _applicationDbContext = applicationDbContext;
        _userManager = userManager;
    }

    [Authorize(Policy = Policies.IsAdmin)]
    [HttpPost(Routes.Members.CreateMember)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Handle([FromBody] MembersCreateCommand command)
    {
        var birthDate = command.BirthDate ?? new DateTime(1900, 1, 1);
        var memberSince = command.MemberSince ?? new DateTime(1900, 1, 1);

        var member = new Member
        {
            Id = new Guid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            StreetLine1 = command.StreetLine1,
            StreetLine2 = command.StreetLine2,
            HouseNumber = command.HouseNumber,
            City = command.City,
            ZipCode = command.ZipCode,
            State = command.State,
            CountryId = command.CountryId,
            UserName = command.Email,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            BirthDate = new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day),
            MemberSince = new DateOnly(memberSince.Year, memberSince.Month, memberSince.Day),
            Language = command.Language,
            SubscriptionsPaid = {new SubscriptionPaid {Year = DateTime.Now.Year}}
        };

        await _userManager.CreateAsync(member, Guid.NewGuid().ToString());

        return Ok(member.Id);
    }
}