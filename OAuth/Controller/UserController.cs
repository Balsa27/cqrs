using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuth.Properties;
using OAuth.Properties.Request;
using OAuth.Queries;

namespace OAuth;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("user")]
    public async Task<User> GetByEmail([FromBody] LoginRequest request) 
        => await _mediator.Send(new GetUserByEmailQuery(request.email));
}