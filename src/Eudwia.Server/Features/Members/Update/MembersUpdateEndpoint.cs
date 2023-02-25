using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Details;
using Eudwia.Shared.Features.Members.Update;

namespace Eudwia.Server.Features.Members.Update;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MembersUpdateEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersUpdateEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpPost("members/{memberId:guid}")]
    [ProducesResponseType(typeof(MembersDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId, [FromBody] MembersUpdateCommand command)
    {
        var member = await _applicationDbContext.Members.SingleOrDefaultAsync(x => x.Id == memberId);

        if (member == null) return BadRequest();

        var birthDate = command.BirthDate ?? new DateTime(1900, 1, 1);
        var memberSince = command.MemberSince ?? new DateTime(1900, 1, 1);

        member.FirstName = command.FirstName;
        member.LastName = command.LastName;
        member.StreetLine1 = command.StreetLine1;
        member.StreetLine2 = command.StreetLine2;
        member.HouseNumber = command.HouseNumber;
        member.City = command.City;
        member.ZipCode = command.ZipCode;
        member.State = command.State;
        member.CountryId = command.CountryId;
        member.Email = command.Email;
        member.PhoneNumber = command.PhoneNumber;
        member.BirthDate = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
        member.MemberSince = new DateTime(memberSince.Year, memberSince.Month, memberSince.Day);
        member.Language = command.Language;
        member.UserName = command.Email;

        _applicationDbContext.Members.Update(member);
        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }
}