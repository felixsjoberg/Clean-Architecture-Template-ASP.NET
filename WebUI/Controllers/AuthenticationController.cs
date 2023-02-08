using Microsoft.AspNetCore.Authorization;
using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiControllerBase
{
    
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{id)")]
    public async Task<ActionResult> Register(RegisterCommand command)
    {

    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginQuery query)
    {

    }
}
