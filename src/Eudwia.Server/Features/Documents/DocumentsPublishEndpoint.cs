using System.Net.Mime;
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

    [HttpPost("documents/publish")]
    public async Task<ActionResult> Handle(IFormFile file)
    {
        var members = _applicationDbContext.Members.Where(m =>
            !string.IsNullOrWhiteSpace(m.StreetLine1) &&
            !string.IsNullOrWhiteSpace(m.City) &&
            !string.IsNullOrWhiteSpace(m.ZipCode) &&
            !string.IsNullOrWhiteSpace(m.HouseNumber)).Select(m => new DocumentViewModel
        {
            FirstName = m.FirstName,
            LastName = m.LastName,
            StreetLine1 = m.StreetLine1,
            HouseNumber = m.HouseNumber,
            City = m.City,
            ZipCode = m.ZipCode,
            Country = m.Country.Name,
            State = m.State
        }).AsAsyncEnumerable();


        var path = Path.GetTempFileName();
        using (var fileStream = new FileStream(path, FileMode.Create))
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
    public string DateTexte { get; set; } = DateTime.Now.ToShortDateString();
}