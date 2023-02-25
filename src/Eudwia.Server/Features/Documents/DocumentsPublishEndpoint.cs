using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        var members = await _applicationDbContext.Members.Where(m =>
                !string.IsNullOrWhiteSpace(m.StreetLine1) &&
                !string.IsNullOrWhiteSpace(m.City) &&
                !string.IsNullOrWhiteSpace(m.ZipCode) &&
                !string.IsNullOrWhiteSpace(m.HouseNumber) && !m.City.Contains("Inconnu"))
            .Select(m => new MemberViewModel
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                StreetLine1 = m.StreetLine1,
                HouseNumber = m.HouseNumber,
                City = m.City,
                ZipCode = m.ZipCode,
                Country = m.Country.Name,
                State = m.State
            }).ToListAsync();
        
        var doc = await _documentService.GenerateMergedDocument(file, members);

        return File(doc, file.ContentType);
    }


}