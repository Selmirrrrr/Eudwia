using System.IO.Compression;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MiniSoftware;

namespace Eudwia.Server.Features.Documents;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsPublishEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DocumentService _documentService;

    public DocumentsPublishEndpoint(ApplicationDbContext applicationDbContext, DocumentService documentService)
    {
        _applicationDbContext = applicationDbContext;
        _documentService = documentService;
    }

    [HttpPost("documents/publish")]
    public async Task<ActionResult> Handle(IFormFile file)
    {
        var stream = new MemoryStream((int)file.Length);
        await file.CopyToAsync(stream);
        var bytes=stream.ToArray();
        var memoryStream = new MemoryStream();
        
        var members = await _applicationDbContext.Members.Where(m =>
                !string.IsNullOrWhiteSpace(m.StreetLine1) &&
                !string.IsNullOrWhiteSpace(m.City) &&
                !string.IsNullOrWhiteSpace(m.ZipCode) &&
                !string.IsNullOrWhiteSpace(m.HouseNumber) && 
                !m.City.Contains("Inconnu") &&
                m.ContactByMail)
            .Select(m => new MemberViewModel
            {
                Prenom = m.FirstName,
                Nom = m.LastName,
                Rue = m.StreetLine1,
                Numero = m.HouseNumber,
                Ville = m.City,
                Npa = m.ZipCode,
                Pays = m.Country.Name,
                Canton = m.State
            }).ToListAsync();
        
        var value = members.FirstOrDefault();

        using var compressedFileStream = new MemoryStream();
        using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, leaveOpen: true)) {
            foreach (var member in members) {
                // Create the instance of the file.
                var zipEntry = zipArchive.CreateEntry($"{member.Nom}-{member.Prenom}.docx");

                // Get the stream of the file.
                using var entryStream = new MemoryStream();
                entryStream.SaveAsByTemplate(bytes, member);
                entryStream.Position = 0;
                await using var zipEntryStream = zipEntry.Open();
                // Adding the file to the zip file.
                await entryStream.CopyToAsync(zipEntryStream);
            }            
        }
        var zipBytes = compressedFileStream.ToArray();
        return File(zipBytes , System.Net.Mime.MediaTypeNames.Application.Octet, "test.zip");
    }


}