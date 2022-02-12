using System.Net.Mime;
using Bogus.DataSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Features.Countries.List;
using Eudwia.Shared.Features.Dashboard;

namespace Eudwia.Server.Features.Dashboard;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersPerYearEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersPerYearEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("dashboard/members-per-year")]
    [ProducesResponseType(typeof(List<MembersPerYearViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MembersPerYearViewModel>>> Handle()
    {
        var startYear = DateTime.Now.Year - 6;
        var endYear = DateTime.Now.Year;
        var countries = await _applicationDbContext.SubscriptionsPaid
            .Where(s => s.Year > startYear && s.Year <= endYear &&
                        s.January &&
                        s.February &&
                        s.March &&
                        s.April &&
                        s.May &&
                        s.June &&
                        s.July &&
                        s.August &&
                        s.September &&
                        s.October &&
                        s.November &&
                        s.December)
            .GroupBy(s => s.Year)
            .Select(s => new MembersPerYearViewModel
            {
                Year = s.Key, 
                Count = s.Count()
            })
            .OrderByDescending(s => s.Year)
            .ToListAsync();

        return Ok(countries);
    }
}