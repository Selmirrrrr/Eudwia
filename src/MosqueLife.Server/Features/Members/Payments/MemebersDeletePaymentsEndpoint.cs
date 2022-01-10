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
public class MemebersPaymentsDeleteEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MemebersPaymentsDeleteEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpDelete("members/{memberId:guid}/payments/{paymentId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MembersPaymentViewModel>>> Handle([FromRoute] Guid memberId, [FromRoute] Guid paymentId)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);
        if (!_applicationDbContext.Payments.Any(m => m.Id == paymentId)) return NotFound(paymentId);

        var payment = await _applicationDbContext.Payments.FindAsync(paymentId);

        if (payment?.MemberId == memberId)
        {
            payment.IsDeleted = true;
            _applicationDbContext.Update(payment);
            await _applicationDbContext.SaveChangesAsync();
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}