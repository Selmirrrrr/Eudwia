using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Members.Create;

namespace MosqueLife.Server.Features.Members.Create;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersCreateEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersCreateEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpPost(Routes.Members.CreateMember)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Handle([FromRoute] Guid memberId, [FromBody] MembersCreateCommand command)
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
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            BirthDate = new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day),
            MemberSince = new DateOnly(memberSince.Year, memberSince.Month, memberSince.Day),
            Language = command.Language,
            SubscriptionsPaid = {new SubscriptionPaid {Year = DateTime.Now.Year}}
        };

        await _applicationDbContext.Members.AddAsync(member);
        await _applicationDbContext.SaveChangesAsync();

        return Ok(member.Id);
    }
}