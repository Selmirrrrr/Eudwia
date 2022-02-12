using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Features.Members.Contributions;
using Eudwia.Shared.Features.Members.Details;

namespace Eudwia.Server.Features.Members.Contributions;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersContributionsChangeEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MemebersContributionsChangeEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpPost("members/{memberId:guid}/contributions/{year:int}/{month:int}")]
    [ProducesResponseType(typeof(MembersDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle(
        [FromRoute] Guid memberId,
        [FromRoute] int year,
        [FromRoute] int month,
        [FromBody] bool value)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);

        SubscriptionPaid? subscriptionPaid = null;
        
        if (!_applicationDbContext.SubscriptionsPaid.Any(sp => sp.Year == year && sp.MemberId == memberId))
            subscriptionPaid = _applicationDbContext.SubscriptionsPaid.Add(new SubscriptionPaid
            {
                MemberId = memberId,
                Year = year
            }).Entity;

        subscriptionPaid ??= await _applicationDbContext.SubscriptionsPaid.FirstAsync(sp => sp.Year == year && sp.MemberId == memberId);
        
        switch (month)
        {
            case 1:
                subscriptionPaid.January = value;
                break;
            case 2:
                subscriptionPaid.February = value;
                break;
            case 3:
                subscriptionPaid.March = value;
                break;
            case 4:
                subscriptionPaid.April = value;
                break;
            case 5:
                subscriptionPaid.May = value;
                break;
            case 6:
                subscriptionPaid.June = value;
                break;
            case 7:
                subscriptionPaid.July = value;
                break;
            case 8:
                subscriptionPaid.August = value;
                break;
            case 9:
                subscriptionPaid.September = value;
                break;
            case 10:
                subscriptionPaid.October = value;
                break;
            case 11:
                subscriptionPaid.November = value;
                break;
            case 12:
                subscriptionPaid.December = value;
                break;
        }

        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }
}