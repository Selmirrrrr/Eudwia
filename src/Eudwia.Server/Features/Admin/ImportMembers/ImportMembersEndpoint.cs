using System.Net.Mime;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Ganss.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eudwia.Server.Features.Admin.ImportMembers;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsSuperAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class ImportMembersEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ImportMembersEndpoint(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("admin/import")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> HandleAsync(IFormFile file, [FromRoute] Guid tenantId, CancellationToken cancellationToken = default)
    {
        var membersExcel = new ExcelMapper(file.OpenReadStream()) { HeaderRow = true }.Fetch<MemberImportDto>();
        var countries = _context.Countries.Select(c => new { c.Id, c.Alpha2Code }).ToDictionary(c => c.Alpha2Code);
        var swissGuid = Guid.Parse("9bc1f1a9-7696-42e4-89aa-c93800704582");
        var members = membersExcel.Select(m => new Data.Member
        {
            FirstName = m.Firstname,
            LastName = m.Lastname,
            BirthDate = m.Naissance is null ? DateOnly.MinValue : DateOnly.FromDateTime(m.Naissance.Value),
            Email = m.Email,
            PhoneNumber = m.Phone,
            StreetLine1 = m.StreetLine1,
            StreetLine2 = m.StreetLine2,
            HouseNumber = m.HouseNumber,
            ZipCode = m.ZipCode,
            City = m.City,
            State = m.State,
            CountryId = countries.Keys.Any(a => a == m.Country) ? countries[m.Country].Id : swissGuid,
            MemberSince = m.MemberSince is null ? DateOnly.MinValue : DateOnly.FromDateTime(m.MemberSince.Value),
            TenantId = tenantId
        });
        await _context.AddRangeAsync(members, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}

public class MemberImportDto
{
    [Column(1)]
    public string Firstname { get; set; } = string.Empty;

    [Column(2)]
    public string Lastname { get; set; } = string.Empty;

    [Column(3)]
    public DateTime? Naissance { get; set; }

    [Column(4)]
    public string Email { get; set; } = string.Empty;

    [Column(5)]
    public string Phone { get; set; } = string.Empty;

    [Column(6)]
    public string StreetLine1 { get; set; } = string.Empty;

    [Column(7)]
    public string StreetLine2 { get; set; } = string.Empty;

    [Column(8)]
    public string HouseNumber { get; set; } = string.Empty;

    [Column(9)]
    public string ZipCode { get; set; } = string.Empty;

    [Column(10)]
    public string City { get; set; } = string.Empty;

    [Column(11)]
    public string State { get; set; } = string.Empty;

    [Column(12)]
    public string Country { get; set; } = string.Empty;

    [Column(13)]
    public DateTime? MemberSince { get; set; }
}