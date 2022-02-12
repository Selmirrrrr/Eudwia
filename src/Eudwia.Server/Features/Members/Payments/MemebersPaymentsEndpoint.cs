using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Features.Members.Details;
using Eudwia.Shared.Features.Members.Payments;

namespace Eudwia.Server.Features.Members.Payments;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersPaymentsEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MemebersPaymentsEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpGet("members/{memberId:guid}/payments")]
    [ProducesResponseType(typeof(IEnumerable<MembersPaymentViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MembersPaymentViewModel>>> Handle([FromRoute] Guid memberId)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);

        var payments = await _applicationDbContext.Payments
            .Where(c => c.MemberId == memberId)
            .Where(c => !c.IsDeleted)
            .Select(c => new MembersPaymentViewModel
            {
                Id = c.Id,
                Amount = c.Amount,
                PaymentDate = c.PaymentDate,
                PaymentType = c.PaymentType,
                Note = c.Note
            }).OrderByDescending(c => c.PaymentDate).ToListAsync();

        return Ok(payments);
    }
}