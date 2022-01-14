using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MosqueLife.Server.Data.Contexts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using Spire.Doc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Document = Spire.Doc.Document;

namespace MosqueLife.Server.Features.Documents;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsPublishEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DocumentsPublishEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpPost("documents/publish")]
    public async Task<ActionResult> Handle(IFormFile file)
    {
        var members = _applicationDbContext.Members.Where(m =>
            !string.IsNullOrWhiteSpace(m.StreetLine1) &&
            !string.IsNullOrWhiteSpace(m.City) &&
            !string.IsNullOrWhiteSpace(m.ZipCode) &&
            !string.IsNullOrWhiteSpace(m.HouseNumber)).Select(m => new
        {
            m.FirstName,
            m.LastName,
            m.StreetLine1,
            m.StreetLine2,
            m.HouseNumber,
            m.City,
            m.ZipCode,
            Country = m.Country.Name,
            m.State
        }).AsAsyncEnumerable();

        var pdfs = new List<Stream>();

        await foreach (var member in members)
        {
            using var document = new Document();
            document.LoadFromStream(file.OpenReadStream(), FileFormat.Auto);
            document.Replace("{{FirstName}}", member.FirstName ?? string.Empty, false, true);
            document.Replace("{{LastName}}", member.LastName ?? string.Empty, false, false);
            document.Replace("{{StreetLine1}}", member.StreetLine1 ?? string.Empty, false, false);
            document.Replace("{{StreetLine2}}", member.StreetLine2 ?? string.Empty, false, false);
            document.Replace("{{HouseNumber}}", member.HouseNumber ?? string.Empty, false, false);
            document.Replace("{{City}}", member.City ?? string.Empty, false, false);
            document.Replace("{{ZipCode}}", member.ZipCode ?? string.Empty, false, false);
            document.Replace("{{Country}}", member.Country ?? string.Empty, false, false);
            document.Replace("{{State}}", member.State ?? string.Empty, false, false);
            document.Replace("{{DateTexte}}", DateTime.Now.ToString("dd MMMM yyyy"), false, false);
            var fileMemoryStream = new MemoryStream();
            document.SaveToStream(fileMemoryStream, FileFormat.PDF);
            pdfs.Add(fileMemoryStream);
        }

        var outputDocument = new PdfDocument();

        foreach (var pdfPath in pdfs)
        {
            var inputDocument = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Import);
            var count = inputDocument.PageCount;
            for (var idx = 0; idx < count; idx++)
            {
                var page = inputDocument.Pages[idx];
                outputDocument.AddPage(page);
            }
        }

        var ms = new MemoryStream();
        outputDocument.Save(ms);
        ms.Position = 0;
        return File(ms, MediaTypeNames.Application.Pdf, "document.pdf");
    }
}
