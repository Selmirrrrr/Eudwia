using System.Net.Mime;
using System.Text;
using Eudwia.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using OpenXmlPowerTools;
using SharpDocx;

namespace Eudwia.Server.Features.Documents;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsPublishListEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DocumentsPublishListEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("documents/list")]
    public async Task<ActionResult> Handle(IFormFile file)
    {
        var currentYear = DateTime.Now.Year;
        var members = _applicationDbContext.Members
            .OrderBy(m => m.LastName)
            .ThenBy(m => m.FirstName)
            .Select(m => new SubscriptionStateLine
            {
                Name = $"{m.FirstName} {m.LastName}",
                M1 = m.SubscriptionsPaid.Where(sp => sp.Year == currentYear - 1).Select(sp => new SubscriptionStateMember
                {
                    Jan = sp.January ? "X" : string.Empty,
                    Feb = sp.February ? "X" : string.Empty,
                    Mar = sp.March ? "X" : string.Empty,
                    Apr = sp.April ? "X" : string.Empty,
                    May = sp.May ? "X" : string.Empty,
                    Jun = sp.June ? "X" : string.Empty,
                    Jul = sp.July ? "X" : string.Empty,
                    Aug = sp.August ? "X" : string.Empty,
                    Sep = sp.September ? "X" : string.Empty,
                    Oct = sp.October ? "X" : string.Empty,
                    Nov = sp.November ? "X" : string.Empty,
                    Dec = sp.December ? "X" : string.Empty
                }).FirstOrDefault(),
                M2 = m.SubscriptionsPaid.Where(sp => sp.Year == currentYear).Select(sp => new SubscriptionStateMember
                {
                    Jan = sp.January ? "X" : string.Empty,
                    Feb = sp.February ? "X" : string.Empty,
                    Mar = sp.March ? "X" : string.Empty,
                    Apr = sp.April ? "X" : string.Empty,
                    May = sp.May ? "X" : string.Empty,
                    Jun = sp.June ? "X" : string.Empty,
                    Jul = sp.July ? "X" : string.Empty,
                    Aug = sp.August ? "X" : string.Empty,
                    Sep = sp.September ? "X" : string.Empty,
                    Oct = sp.October ? "X" : string.Empty,
                    Nov = sp.November ? "X" : string.Empty,
                    Dec = sp.December ? "X" : string.Empty
                }).FirstOrDefault()
                
            }).ToList();
        
        var model = new SubscriptionStateViewModel
        {
            Lines = members,
            Year = currentYear,
            Count = members.Count
        };
        
        var path = Path.GetTempFileName();
        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        try
        {
            var document = DocumentFactory.Create(path, model, forceCompile: false);
            var doc = document.Generate();
            return File(doc, file.ContentType);

        }
        catch (SharpDocx.SharpDocxCompilationException sdce)
        {
            StringBuilder sb = new StringBuilder(sdce.Errors);
            sb.AppendLine(sdce.SourceCode);
            Console.WriteLine(sb.ToString());
        }
        
        return BadRequest();

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

public class SubscriptionStateViewModel
{
    public int Year { get; set; }
    public int Count { get; set; }
    public List<SubscriptionStateLine> Lines { get; set; }
}

public class SubscriptionStateLine
{
    private SubscriptionStateMember? _m1;
    private SubscriptionStateMember? _m2;
    public string Name { get; set; } = string.Empty;

    public SubscriptionStateMember? M1
    {
        get => _m1 ?? new SubscriptionStateMember();
        set => _m1 = value;
    }

    public SubscriptionStateMember? M2
    {
        get => _m2 ?? new SubscriptionStateMember();
        set => _m2 = value;
    }
}

public class SubscriptionStateMember
{
    public string Jan { get; set; } = string.Empty;
    public string Feb { get; set; } = string.Empty;
    public string Mar { get; set; } = string.Empty;
    public string Apr { get; set; } = string.Empty;
    public string May { get; set; } = string.Empty;
    public string Jun { get; set; } = string.Empty;
    public string Jul { get; set; } = string.Empty;
    public string Aug { get; set; } = string.Empty;
    public string Sep { get; set; } = string.Empty;
    public string Oct { get; set; } = string.Empty;
    public string Nov { get; set; } = string.Empty;
    public string Dec { get; set; } = string.Empty;
}