using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Server.Data.Contexts;
using Eudwia.Shared.Authorization;
using Eudwia.Shared.Features.Members.Payments;

namespace Eudwia.Server.Features.Members.Payments;

[Route("api")]
[ApiController]
[Authorize(Policy = Policies.IsAdmin)]
[Produces(MediaTypeNames.Application.Json)]
public class MemebersPaymentsAddEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public MemebersPaymentsAddEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Authorize]
    [HttpPost("members/{memberId:guid}/payments")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Handle([FromRoute] Guid memberId, [FromBody] MembersAddPaymentCommand command)
    {
        if (!_applicationDbContext.Members.Any(m => m.Id == memberId)) return NotFound(memberId);
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            MemberId = memberId,
            Amount = command.Amount,
            PaymentDate = DateTime.SpecifyKind(command.PaymentDate ?? DateTime.Now, DateTimeKind.Utc),
            PaymentType = command.PaymentType,
            Note = command.Note
        };

        await _applicationDbContext.Payments.AddAsync(payment);
        await _applicationDbContext.SaveChangesAsync();

        return new CreatedResult(payment.Id.ToString(), payment);
    }
}