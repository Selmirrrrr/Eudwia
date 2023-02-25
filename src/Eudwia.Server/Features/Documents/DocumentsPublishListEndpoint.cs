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
public class DocumentsPublishListEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DocumentService _documentService;
    private readonly ILogger<DocumentsPublishListEndpoint> _logger;

    public DocumentsPublishListEndpoint(ApplicationDbContext applicationDbContext, DocumentService documentService, ILogger<DocumentsPublishListEndpoint> logger)
    {
        _applicationDbContext = applicationDbContext;
        _documentService = documentService;
        _logger = logger;
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
                (
                    sp.January ? "X" : string.Empty,
                    sp.February ? "X" : string.Empty,
                    sp.March ? "X" : string.Empty,
                    sp.April ? "X" : string.Empty,
                    sp.May ? "X" : string.Empty,
                    sp.June ? "X" : string.Empty,
                    sp.July ? "X" : string.Empty,
                    sp.August ? "X" : string.Empty,
                    sp.September ? "X" : string.Empty,
                    sp.October ? "X" : string.Empty,
                    sp.November ? "X" : string.Empty,
                    sp.December ? "X" : string.Empty
                )).FirstOrDefault(),
                M2 = m.SubscriptionsPaid.Where(sp => sp.Year == currentYear).Select(sp => new SubscriptionStateMember
                (
                    sp.January ? "X" : string.Empty,
                    sp.February ? "X" : string.Empty,
                    sp.March ? "X" : string.Empty,
                    sp.April ? "X" : string.Empty,
                    sp.May ? "X" : string.Empty,
                    sp.June ? "X" : string.Empty,
                    sp.July ? "X" : string.Empty,
                    sp.August ? "X" : string.Empty,
                    sp.September ? "X" : string.Empty,
                    sp.October ? "X" : string.Empty,
                    sp.November ? "X" : string.Empty,
                    sp.December ? "X" : string.Empty
                )).FirstOrDefault()
                
            }).ToList();

        var viewModel = new SubscriptionStateViewModel(currentYear, members.Count, members);

        var doc = await _documentService.GenerateDocument(file, viewModel);
        
        return File(doc, file.ContentType);
    }
}

public record SubscriptionStateViewModel(int Year, int Count, List<SubscriptionStateLine> Lines);

public record SubscriptionStateLine
{
    private SubscriptionStateMember? _m1;
    private SubscriptionStateMember? _m2;
    public string Name { get; init; } = string.Empty;

    public SubscriptionStateMember? M1
    {
        get => _m1 ?? new SubscriptionStateMember(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty ,string.Empty, string.Empty, string.Empty, string.Empty);
        set => _m1 = value;
    }

    public SubscriptionStateMember? M2
    {
        get => _m2 ?? new SubscriptionStateMember(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty ,string.Empty, string.Empty, string.Empty, string.Empty);
        set => _m2 = value;
    }
}

public record SubscriptionStateMember(string Jan, string Feb, string Mar, string Apr, string May, string Jun, string Jul, string Aug, string Sep, string Oct, string Nov, string Dec);