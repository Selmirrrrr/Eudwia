using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Eudwia.Server.Features.Documents;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsPublishUnpaidEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DocumentService _documentService;

    public DocumentsPublishUnpaidEndpoint(ApplicationDbContext applicationDbContext, DocumentService documentService)
    {
        _applicationDbContext = applicationDbContext;
        _documentService = documentService;
    }

    [HttpPost("documents/publish-unpaid")]
    public async Task<ActionResult> Handle(IFormFile file, int unpayedYear = 2021)
    {
        var members = _applicationDbContext.Members.Where(m =>
                !string.IsNullOrWhiteSpace(m.StreetLine1) &&
                !string.IsNullOrWhiteSpace(m.City) &&
                !string.IsNullOrWhiteSpace(m.ZipCode) &&
                !string.IsNullOrWhiteSpace(m.HouseNumber) &&
                !m.SubscriptionsPaid.Any(a => a.Year == unpayedYear &&
                                              a.January &&
                                              a.February &&
                                              a.March &&
                                              a.April &&
                                              a.May &&
                                              a.June &&
                                              a.July &&
                                              a.August &&
                                              a.September &&
                                              a.October &&
                                              a.November &&
                                              a.December))
            .Select(m => new
            {
                FirstName = m.FirstName, LastName = m.LastName, StreetLine1 = m.StreetLine1,
                HouseNumber = m.HouseNumber,
                City = m.City,
                ZipCode = m.ZipCode,
                Country = m.Country.Name,
                State = m.State,
                SubscriptionPaid = m.SubscriptionsPaid.FirstOrDefault(sp => sp.Year == unpayedYear),
                MemberSince = m.MemberSince,
                MemberSinceMonth = m.MemberSince.Year < unpayedYear ? 1 : m.MemberSince.Month
            }).ToList();
        
        var subscriptions = members.Where(m => m.MemberSince.Year <= unpayedYear).Select(m => new 
        {
            FirstName = m.FirstName,
            LastName = m.LastName,
            StreetLine1 = m.StreetLine1,
            HouseNumber = m.HouseNumber,
            City = m.City,
            ZipCode = m.ZipCode,
            Country = m.Country,
            State = m.State,
            SubscriptionsPaid = new SubscriptionsPaidViewModel
            {
                Year = m.SubscriptionPaid?.Year ?? 2021,
                Jan = m.SubscriptionPaid?.January == true || m.MemberSinceMonth > 1,
                Feb = m.SubscriptionPaid?.February == true || m.MemberSinceMonth > 2,
                Mar = m.SubscriptionPaid?.March == true || m.MemberSinceMonth > 3,
                Apr = m.SubscriptionPaid?.April == true || m.MemberSinceMonth > 4,
                May = m.SubscriptionPaid?.May == true || m.MemberSinceMonth > 5,
                Jun = m.SubscriptionPaid?.June == true || m.MemberSinceMonth > 6,
                Jul = m.SubscriptionPaid?.July == true || m.MemberSinceMonth > 7,
                Aug = m.SubscriptionPaid?.August == true || m.MemberSinceMonth > 8,
                Sep = m.SubscriptionPaid?.September == true || m.MemberSinceMonth > 9,
                Oct = m.SubscriptionPaid?.October == true || m.MemberSinceMonth > 10,
                Nov = m.SubscriptionPaid?.November == true || m.MemberSinceMonth > 11,
                Dec = m.SubscriptionPaid?.December == true || m.MemberSinceMonth > 12,
            },
        });

        var lines = subscriptions
            .Where(l => !l.SubscriptionsPaid.Jan || !l.SubscriptionsPaid.Feb || !l.SubscriptionsPaid.Mar ||
                        !l.SubscriptionsPaid.Apr || !l.SubscriptionsPaid.May || !l.SubscriptionsPaid.Jun ||
                        !l.SubscriptionsPaid.Jul || !l.SubscriptionsPaid.Aug || !l.SubscriptionsPaid.Sep ||
                        !l.SubscriptionsPaid.Oct || !l.SubscriptionsPaid.Nov || !l.SubscriptionsPaid.Dec);
        var doc = await _documentService.GenerateMergedDocument(file, lines);
        
        return File(doc, file.ContentType);
    }
}

public static class Ext {
    public static int FalseCount(this IEnumerable<bool> array)
    {
        return array.Count(t => !t);
    }
}