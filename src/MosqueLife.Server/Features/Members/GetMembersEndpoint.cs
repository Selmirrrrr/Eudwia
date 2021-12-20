using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Members;
using System.Net.Mime;

namespace MosqueLife.Server.Features.Members;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class GetMembersEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GetMembersEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet(Routes.Members.GetMembers)]
    [ProducesResponseType(typeof(GetMembersResult), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetMembersResult>> Handle()
    {
        var members = await _applicationDbContext.Members.Select(m => new GetMembersResult
        {
            Id = m.Id,
            Firstname = m.Firstname,
            LastName = m.Lastname,
            Email = m.Email ?? string.Empty,
            Phone = m.PhoneNumber ?? string.Empty,
            MemberSince = m.MemberSince.ToDateTime(new TimeOnly(0,0)),
            MonthsPaidThisYear = m.SubscriptionsPaid.Count(sp => sp.Year == DateTime.Now.Year)
        }).ToListAsync();

        return Ok(members);
    }
}