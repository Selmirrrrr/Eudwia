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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetMembersResult>> Handle()
    {
        var members = await _applicationDbContext.Members.Include(s => s.SubscriptionsPaid).Select(m => new 
        {
            Id = m.Id,
            Firstname = m.Firstname,
            LastName = m.Lastname,
            Email = m.Email ?? string.Empty,
            MemberSince = m.MemberSince.ToDateTime(new TimeOnly(0,0)),
            YearsPaid = m.SubscriptionsPaid
                                           .GroupBy(sp => sp.Year)
                                           .Where(spg => spg.Count() == 12)
                                           .Select(sp => sp.Key)
                                           .ToArray()
        }).ToListAsync();

        return Ok(members);
    }
}
