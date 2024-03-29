﻿using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Dashboard;

namespace Eudwia.Server.Features.Dashboard;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class IncomePerYearEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public IncomePerYearEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("dashboard/income-per-year")]
    [ProducesResponseType(typeof(List<IncomePerYearViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<IncomePerYearViewModel>>> Handle()
    {
        var startDate = DateTime.SpecifyKind(new DateTime(DateTime.Now.Year - 6, 1, 1), DateTimeKind.Utc);
        var countries = await _applicationDbContext.Payments
            .Where(s => s.PaymentDate >= startDate)
            .GroupBy(s => new {s.PaymentDate.Year, s.PaymentType})
            .Select(s => new IncomePerYearViewModel
            {
                Year = s.Key.Year,
                Amount = s.Sum(x => x.Amount),
                PaymentType = s.Key.PaymentType
            })
            .OrderBy(s => s.Year)
            .ToListAsync();

        return Ok(countries);
    }
}