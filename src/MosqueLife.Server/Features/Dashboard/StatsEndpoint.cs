using System.Net.Mime;
using Bogus.DataSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared.Features.Countries.List;
using MosqueLife.Shared.Features.Dashboard;

namespace MosqueLife.Server.Features.Dashboard;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class StatsEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StatsEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("dashboard/stats")]
    [ProducesResponseType(typeof(List<StatsViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StatsViewModel>>> Handle()
    {
        var year = DateTime.UtcNow.Year;

        var result = new StatsViewModel();
        result.MembersCount = await _applicationDbContext.Members.CountAsync();
        result.PaidMembersCount = await _applicationDbContext.Members.CountAsync(m 
            => m.SubscriptionsPaid.Any(s => s.Year == year && 
                                            (s.January || 
                                             s.February ||
                                             s.March ||
                                             s.April ||
                                             s.May ||
                                             s.June ||
                                             s.July ||
                                             s.August ||
                                             s.September ||
                                             s.October ||
                                             s.November ||
                                             s.December)));
        result.TotalRevenue = await _applicationDbContext.Payments.Where(p => p.PaymentDate.Year == year).SumAsync(p => p.Amount);
        result.AverageAge = (int)(await _applicationDbContext.Members.AverageAsync(m => year - m.BirthDate.Year));

        return Ok(result);
    }
}