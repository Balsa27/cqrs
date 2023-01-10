using MediatR;
using Microsoft.AspNetCore.Mvc;
using OAuth.Attributes;
using OAuth.Handlers;
using OAuth.Properties;
using OAuth.Queries;

namespace OAuth;

public class BurekController : ControllerBase
{
    private readonly IMediator _mediator;


    public BurekController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(Permissions.ReadMember)]
    [HttpGet("burek")]
    public async Task<HashSet<Burek>> GetAll() => await _mediator.Send(new GetAllBureksQuery());

}