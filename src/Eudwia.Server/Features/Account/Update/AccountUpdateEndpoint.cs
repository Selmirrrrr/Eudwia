﻿using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eudwia.Server.Data;
using Eudwia.Shared;
using Eudwia.Shared.Features.Account.Update;

namespace Eudwia.Server.Features.Account.Update;

[Route("api")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class AccountUpdateEndpoint : ControllerBase
{
    private readonly UserManager<Member> _userManager;

    public AccountUpdateEndpoint(UserManager<Member> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("account/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<IActionResult> Handle(Guid id, [FromBody] AccountUpdateCommand accountUpdate)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound("Utilisateur introuvable.");

        user.FirstName = accountUpdate.FirstName;
        user.LastName = accountUpdate.LastName;

        await _userManager.UpdateAsync(user);
        return Ok();
    }
}