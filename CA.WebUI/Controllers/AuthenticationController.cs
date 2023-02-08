using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CA.Application.Authentication.Commands.Register;
using CA.Application.Authentication.Queries.Login;

namespace CA.WebUI.Controllers;

[Route("auth")]
[ApiController]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{id)")]
    public async Task<ActionResult> Register(RegisterCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
}
