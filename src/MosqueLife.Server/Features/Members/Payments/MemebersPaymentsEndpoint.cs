using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MosqueLife.Server.Data.Contexts;
using MosqueLife.Shared.Features.Members.Details;
using MosqueLife.Shared.Features.Members.Payments;

namespace MosqueLife.Server.Features.Members.Payments;

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
            .Select(c => new MembersPaymentViewModel
            {
                Amount = c.Amount,
                PaymentDate = c.PaymentDate,
                PaymentType = c.PaymentType,
                Note = c.Note
            }).OrderByDescending(c => c.PaymentDate).ToListAsync();

        return Ok(payments);
    }
}