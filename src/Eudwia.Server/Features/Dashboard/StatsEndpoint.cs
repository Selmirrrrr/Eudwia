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
public class StatsEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StatsEndpoint(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    [Authorize]
    [HttpGet("dashboard/stats")]
    [ProducesResponseType(typeof(List<StatsViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StatsViewModel>>> Handle()
    {
        var year = DateTime.UtcNow.Year;

        var result = new StatsViewModel();
        result.MembersCount = await _context.Members.CountAsync();
        result.PaidMembersCount = await _context.Members.CountAsync(
            m => m.SubscriptionsPaid.Any(s => s.Year == year && 
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
        result.TotalRevenue = await _context.Payments.Where(p => p.PaymentDate.Year == year).SumAsync(p => p.Amount);
        result.TopDonator = (await _context.Members.OrderByDescending(m => m.Payments.Where(p => p.PaymentType == Shared.Enums.PaymentType.Donation).Sum(p => p.Amount))
                                                   .Take(1)
                                                   .Select(m => new { Name = $"{m.FirstName} {m.LastName}" })
                                                   .FirstAsync()).Name;

        return Ok(result);
    }
}