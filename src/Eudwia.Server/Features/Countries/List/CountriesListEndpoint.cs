using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Features.Countries.List;

namespace Eudwia.Server.Features.Countries.List;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CountriesListEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CountriesListEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("countries")]
    [ProducesResponseType(typeof(List<CountriesListViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CountriesListViewModel>>> Handle()
    {
        var countries = await _applicationDbContext.Countries.Select(m => new CountriesListViewModel
        {
            Id = m.Id,
            Name = m.Name,
        }).ToListAsync();

        return Ok(countries);
    }
}