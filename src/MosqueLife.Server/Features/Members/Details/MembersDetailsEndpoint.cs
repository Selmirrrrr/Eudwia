using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared;
using MosqueLife.Shared.Features.Members.Details;

namespace MosqueLife.Server.Features.Members.Details;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MembersDetailsEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MembersDetailsEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet(Routes.Members.GetMember)]
    [ProducesResponseType(typeof(MembersDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MembersDetailsViewModel>> Handle([FromRoute] Guid memberId)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);
        
        var member = await _applicationDbContext.Members.Select(m => new MembersDetailsViewModel
        {
            Id = m.Id,
            Firstname = m.Firstname,
            Lastname = m.Lastname,
            StreetLine1 = m.StreetLine1,
            StreetLine2 = m.StreetLine2,
            HouseNumber = m.HouseNumber,
            City = m.City,
            ZipCode = m.ZipCode,
            Language = m.Language,
            BirthDate = m.BirthDate.ToDateTime(new TimeOnly(0, 0)),
            State = m.State,
            CountryId = m.CountryId,
            Country = m.Country.Name,
            Email = m.Email ?? string.Empty,
            PhoneNumber = m.PhoneNumber,
            MemberSince = m.MemberSince.ToDateTime(new TimeOnly(0, 0)),
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
        }).FirstAsync(m => m.Id == memberId);

        return Ok(member);
    }
}