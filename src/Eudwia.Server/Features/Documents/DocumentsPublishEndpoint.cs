using System.Net.Mime;
using Eudwia.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OpenXmlPowerTools;
using SharpDocx;

namespace Eudwia.Server.Features.Documents;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsPublishEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DocumentsPublishEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("documents/publish2")]
    public async Task<ActionResult> Handle(IFormFile file)
    {
        var members = _applicationDbContext.Members.Where(m =>
                !string.IsNullOrWhiteSpace(m.StreetLine1) &&
                !string.IsNullOrWhiteSpace(m.City) &&
                !string.IsNullOrWhiteSpace(m.ZipCode) &&
                !string.IsNullOrWhiteSpace(m.HouseNumber))
            .Select(m => new DocumentViewModel
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                StreetLine1 = m.StreetLine1,
                HouseNumber = m.HouseNumber,
                City = m.City,
                ZipCode = m.ZipCode,
                Country = m.Country.Name,
                State = m.State
            }).Take(10).AsAsyncEnumerable();

        var path = Path.GetTempFileName();
        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var documents = new List<MemoryStream>();
        await foreach (var member in members)
        {
            var document = DocumentFactory.Create(path, member, forceCompile: false);
            var doc = document.Generate();

            documents.Add(doc);
        }

        System.IO.File.Delete(path);

        var ms = MergeDocuments(documents);
        ms.Position = 0;
        return File(ms, file.ContentType);
    }

    public record Test
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetLine1 { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public SubscriptionPaid SubscriptionPaid { get; set; }
        public DateOnly MemberSince { get; set; }
        public int MemberSinceMonth { get; set; }
    }

    [HttpPost("documents/publish")]
    public async Task<ActionResult> Handle2(IFormFile file, int unpayedYear = 2021)
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
            .Select(m => new Test
            {
                FirstName = m.FirstName, LastName = m.LastName, StreetLine1 = m.StreetLine1,
                HouseNumber = m.HouseNumber,
                City = m.City,
                ZipCode = m.ZipCode,
                Country = m.Country.Name,
                State = m.State,
                SubscriptionPaid = m.SubscriptionsPaid.FirstOrDefault(sp => sp.Year == unpayedYear),
                MemberSince = m.MemberSince,
                MemberSinceMonth = 0
            }).ToList();
        
        members.ForEach(m => m.MemberSinceMonth = m.MemberSince.Year < unpayedYear ? 1 : m.MemberSince.Month);

        var lol = members.Where(m => m.MemberSince.Year <= unpayedYear).Select(m => new DocumentViewModel
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


        var path = Path.GetTempFileName();
        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var documents = lol
            .Where(l => !l.SubscriptionsPaid.Jan || !l.SubscriptionsPaid.Feb || !l.SubscriptionsPaid.Mar ||
                        !l.SubscriptionsPaid.Apr || !l.SubscriptionsPaid.May || !l.SubscriptionsPaid.Jun ||
                        !l.SubscriptionsPaid.Jul || !l.SubscriptionsPaid.Aug || !l.SubscriptionsPaid.Sep ||
                        !l.SubscriptionsPaid.Oct || !l.SubscriptionsPaid.Nov || !l.SubscriptionsPaid.Dec)
            .Select(member => DocumentFactory.Create(path, member, forceCompile: false))
            .Select(document => document.Generate()).ToList();

        System.IO.File.Delete(path);

        var ms = MergeDocuments(documents);
        ms.Position = 0;
        return File(ms, file.ContentType);
    }

    private static Stream MergeDocuments(List<MemoryStream> files)
    {
        var outputFileStream = new MemoryStream();
        var sources = new List<Source>();

        foreach (var file in files)
        {
            var openXmlPowerToolsDocument = new OpenXmlPowerToolsDocument(Guid.NewGuid().ToString(), file);
            var document = new WmlDocument(openXmlPowerToolsDocument);
            var source = new Source(document, true);
            sources.Add(source);
        }

        MergeXmlDocuments(outputFileStream, sources);
        return outputFileStream;
    }

    private static void MergeXmlDocuments(Stream outStream, List<Source> sources)
    {
        var buildDocument = DocumentBuilder.BuildDocument(sources);
        buildDocument.WriteByteArray(outStream);
    }
}

public class DocumentViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StreetLine1 { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;

    public SubscriptionsPaidViewModel SubscriptionsPaid { get; set; } = new SubscriptionsPaidViewModel
    {
        Year = 2021,
    };
    
}

public class SubscriptionsPaidViewModel
{
    public int Year { get; set; }
    public bool Jan { get; set; }
    public bool Feb { get; set; }
    public bool Mar { get; set; }
    public bool Apr { get; set; }
    public bool May { get; set; }
    public bool Jun { get; set; }
    public bool Jul { get; set; }
    public bool Aug { get; set; }
    public bool Sep { get; set; }
    public bool Oct { get; set; }
    public bool Nov { get; set; }
    public bool Dec { get; set; }
    
    public string JanText => Jan ? "✔" : string.Empty;
    public string FebText => Feb ? "✔" : string.Empty;
    public string MarText => Mar ? "✔" : string.Empty;
    public string AprText => Apr ? "✔" : string.Empty;
    public string MayText => May ? "✔" : string.Empty;
    public string JunText => Jun ? "✔" : string.Empty;
    public string JulText => Jul ? "✔" : string.Empty;
    public string AugText => Aug ? "✔" : string.Empty;
    public string SepText => Sep ? "✔" : string.Empty;
    public string OctText => Oct ? "✔" : string.Empty;
    public string NovText => Nov ? "✔" : string.Empty;
    public string DecText => Dec ? "✔" : string.Empty;

    public int Nombre => new bool[] { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }.FalseCount();
    public int Montant => Nombre * 30;
}
public static class Ext {
    public static int FalseCount(this bool[] array)
    {
        return array.Count(t => !t);
    }
}