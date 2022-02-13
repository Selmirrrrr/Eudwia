using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.List;

namespace Eudwia.Server.Features.Members.List;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MembersListEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersListEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("members")]
    [ProducesResponseType(typeof(MembersListViewModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<MembersListViewModel>> Handle()
    {
        var members = await _applicationDbContext.Members.Select(m => new MembersListViewModel
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email ?? string.Empty,
            Phone = m.PhoneNumber ?? string.Empty,
            MemberSince = m.MemberSince.ToDateTime(new TimeOnly(0,0)),
            January = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).January == true,
            February = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).February == true,
            March = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).March == true,
            April = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).April == true,
            May = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).May == true,
            June = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).June == true,
            July = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).July == true,
            August = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).August == true,
            September = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).September == true,
            October = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).October == true,
            November = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).November == true,
            December = m.SubscriptionsPaid.First(sp => sp.Year == DateTime.Now.Year).December == true
        }).OrderByDescending(m => m.MemberSince).ToListAsync();

        return Ok(members);
    }
}