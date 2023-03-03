using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Create;
using FluentValidation;

namespace Eudwia.Server.Features.Members.Create;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersCreateEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public MembersCreateEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [Authorize(Policy = Policies.IsAdmin)]
    [HttpPost("members")]
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
            GivenName = command.GivenName,
            StreetLine1 = command.StreetLine1,
            StreetLine2 = command.StreetLine2,
            HouseNumber = command.HouseNumber,
            City = command.City,
            ZipCode = command.ZipCode,
            State = command.State,
            CountryId = command.CountryId,
            UserName =  string.IsNullOrWhiteSpace(command.Email) ? "EMPTY" : command.Email,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            BirthDate = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day),
            MemberSince = new DateTime(memberSince.Year, memberSince.Month, memberSince.Day),
            Language = command.Language,
            SecurityStamp = Guid.NewGuid().ToString(),
            SubscriptionsPaid = {new SubscriptionPaid {Year = DateTime.Now.Year}},
            ContactByMail = command.ContactByMail,
            ContactByPhone = command.ContactByPhone,
            ContactByEMail = command.ContactByEMail,
            Note = command.Note
        };

        var result = await _userManager.CreateAsync(member, Guid.NewGuid().ToString());
        if (result.Succeeded)
            return Ok(member.Id);
        
        var errors = result.Errors.Select(x => x.Description);
        return BadRequest(errors);
    }
}