using System.Net.Mime;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Enums;
using Ganss.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eudwia.Server.Features.Admin.ImportMembers;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
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
            BirthDate = m.Naissance ?? DateTime.MinValue,
            Email = m.Email,
            PhoneNumber = m.Phone,
            StreetLine1 = m.StreetLine1,
            StreetLine2 = m.StreetLine2,
            HouseNumber = m.HouseNumber,
            ZipCode = m.ZipCode,
            City = m.City,
            State = m.State,
            CountryId = countries.Keys.Any(a => a == m.Country) ? countries[m.Country].Id : swissGuid,
            MemberSince = m.MemberSince ?? DateTime.MinValue,
            TenantId = tenantId,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = m.Email,
        });
        await _context.AddRangeAsync(members, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok();
    }
    
    [HttpGet("admin/import2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> HandleAsync2(CancellationToken cancellationToken = default)
    {
        var membersExcel = new ExcelMapper("C:\\temp\\AspNetUsers 1.xlsx") { HeaderRow = true }.Fetch<MemberImportDto2>();
        var members = membersExcel.Select(anu => new Data.Member
        {
            Id = anu.Id,
            FirstName = anu.FirstName,
            LastName = anu.LastName,
            BirthDate = anu.BirthDate,
            MemberSince = anu.MemberSince,
            StreetLine1 = anu.StreetLine1,
            StreetLine2 = anu.StreetLine2,
            HouseNumber = anu.HouseNumber,
            ZipCode = anu.ZipCode,
            City = anu.City,
            State = anu.State,
            CountryId = anu.CountryId,
            Language = anu.Language,
            AuditCreatedAt = anu.AuditCreatedAt,
            AuditCreatedBy = anu.AuditCreatedBy,
            AuditModifiedAt = anu.AuditModifiedAt,
            AuditModifiedBy = anu.AuditModifiedBy,
            TenantId = anu.TenantId,
            IsDeleted = anu.IsDeleted,
            UserName = anu.UserName,
            NormalizedUserName = anu.NormalizedUserName,
            Email = anu.Email,
            NormalizedEmail = anu.NormalizedEmail,
            EmailConfirmed = anu.EmailConfirmed,
            PasswordHash = anu.PasswordHash,
            SecurityStamp = anu.SecurityStamp,
            ConcurrencyStamp = anu.ConcurrencyStamp,
            PhoneNumber = anu.PhoneNumber,
            PhoneNumberConfirmed = anu.PhoneNumberConfirmed,
            TwoFactorEnabled = anu.TwoFactorEnabled,
            LockoutEnd = anu.LockoutEnd,
            LockoutEnabled = anu.LockoutEnabled,
            AccessFailedCount = 0,
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

public class MemberImportDto2
{
    [Column("Id")] public Guid Id { get; set; }
    [Column("FirstName")] public string FirstName { get; set; } = string.Empty;
    [Column("LastName")] public string LastName { get; set; } = string.Empty;
    [Column("BirthDate")] public DateTime BirthDate { get; set; }
    [Column("MemberSince")] public DateTime MemberSince { get; set; }
    [Column("StreetLine1")] public string StreetLine1 { get; set; } = string.Empty;
    [Column("StreetLine2")] public string StreetLine2 { get; set; } = string.Empty;
    [Column("HouseNumber")] public string HouseNumber { get; set; } = string.Empty;
    [Column("ZipCode")] public string ZipCode { get; set; } = string.Empty;
    [Column("City")] public string City { get; set; } = string.Empty;
    [Column("State")] public string State { get; set; } = string.Empty;
    [Column("CountryId")] public Guid CountryId { get; set; }
    [Ignore] public Language Language { get; set; } = Language.Bosnian;
    [Column("AuditCreatedAt")] public DateTime AuditCreatedAt { get; set; }
    [Column("AuditCreatedBy")] public string AuditCreatedBy { get; set; } = string.Empty;
    [Column("AuditModifiedAt")] public DateTime AuditModifiedAt { get; set; }
    [Column("AuditModifiedBy")] public string AuditModifiedBy { get; set; } = string.Empty;
    [Column("TenantId")] public Guid TenantId { get; set; }
    [Column("IsDeleted")] public bool IsDeleted { get; set; }
    [Column("UserName")] public string UserName { get; set; } = string.Empty;
    [Ignore] public string? NormalizedUserName { get; set; } = null;
    [Column("Email")] public string Email { get; set; } = string.Empty;
    [Column("NormalizedEmail")] public string NormalizedEmail { get; set; } = string.Empty;
    [Column("EmailConfirmed")] public bool EmailConfirmed { get; set; }
    [Column("PasswordHash")] public string PasswordHash { get; set; } = string.Empty;
    [Column("SecurityStamp")] public string SecurityStamp { get; set; } = string.Empty;
    [Column("ConcurrencyStamp")] public string ConcurrencyStamp { get; set; } = string.Empty;
    [Column("PhoneNumber")] public string PhoneNumber { get; set; } = string.Empty;
    [Column("PhoneNumberConfirmed")] public bool PhoneNumberConfirmed { get; set; }
    [Column("TwoFactorEnabled")] public bool TwoFactorEnabled { get; set; }
    [Ignore] public DateTimeOffset? LockoutEnd { get; set; }
    [Column("LockoutEnabled")] public bool LockoutEnabled { get; set; }
}