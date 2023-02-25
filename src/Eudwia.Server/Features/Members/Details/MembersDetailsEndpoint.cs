using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Extensions;
using Eudwia.Shared.Features.Members.Details;

namespace Eudwia.Server.Features.Members.Details;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersDetailsEndpoint : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersDetailsEndpoint(IAuthorizationService authorizationService, ApplicationDbContext applicationDbContext)
    {
        _authorizationService = authorizationService;
        _applicationDbContext = applicationDbContext;
    }

    [Authorize(Policy = Policies.IsAdmin)]
    [HttpGet("members/{memberId:guid}")]
    [ProducesResponseType(typeof(MembersDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MembersDetailsViewModel>> Handle([FromRoute] Guid memberId)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);

        if (!User.IsInRoleAdmin() && !User.IsInRoleSuperAdmin())
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, memberId, Policies.IsCurrentdUser);
            if (!authorizationResult.Succeeded)
                return Forbid();
        }

        var member = await _applicationDbContext.Members.Select(m => new MembersDetailsViewModel
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName,
            StreetLine1 = m.StreetLine1,
            StreetLine2 = m.StreetLine2,
            HouseNumber = m.HouseNumber,
            City = m.City,
            ZipCode = m.ZipCode,
            Language = m.Language,
            BirthDate = m.BirthDate,
            State = m.State,
            CountryId = m.CountryId,
            Country = m.Country.Name,
            Email = m.Email ?? string.Empty,
            PhoneNumber = m.PhoneNumber,
            MemberSince = m.MemberSince,
            MonthsPaidByYears = m.SubscriptionsPaid.Select(spg => new MembersDetailsViewModel.MonthsPaidByYear
            {
                Year = spg.Year,
                January = spg.January,
                February = spg.February,
                March = spg.March,
                April = spg.April,
                May = spg.May,
                June = spg.June,
                July = spg.July,
                August = spg.August,
                September = spg.September,
                October = spg.October,
                November = spg.November,
                December = spg.December
            }).ToArray(),
            Payments = m.Payments.Select(p => new MembersDetailsViewModel.PaymentOverview
            {
                Id = p.Id,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate
            }).ToArray()
        }).AsSplitQuery().FirstAsync(m => m.Id == memberId);

        return Ok(member);
    }
}