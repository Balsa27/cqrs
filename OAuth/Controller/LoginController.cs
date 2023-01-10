using MediatR;
using Microsoft.AspNetCore.Mvc;
using OAuth.Commands;
using OAuth.Properties.Request;

namespace OAuth;

public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LogInCommand(request.email, request.password);
        string jwt = await _mediator.Send(command, cancellationToken);
        return Ok(jwt); //not doing a fail path rn
    }
}