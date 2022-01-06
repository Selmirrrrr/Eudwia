using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared.Features.Members.Contributions;
using MosqueLife.Shared.Features.Members.Details;

namespace MosqueLife.Server.Features.Members.Contributions;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersContributionsEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MemebersContributionsEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("members/{memberId:guid}/contributions")]
    [ProducesResponseType(typeof(MembersDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MemebersContributionsViewModel>>> Handle([FromRoute] Guid memberId)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);

        var contributions = await _applicationDbContext.SubscriptionsPaid
            .Where(c => c.MemberId == memberId)
            .Select(c => new MemebersContributionsViewModel
            {
                Year = c.Year,
                January = c.January,
                February = c.February,
                March = c.March,
                April = c.April,
                May = c.May,
                June = c.June,
                July = c.July,
                August = c.August,
                September = c.September,
                October = c.October,
                November = c.November,
                December = c.December
            }).OrderByDescending(c => c.Year).ToListAsync();

        return Ok(contributions);
    }
}