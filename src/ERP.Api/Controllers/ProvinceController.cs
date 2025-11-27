using HumanResources.Application.Handlers.Queries.Province;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProvinceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvinceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllProvincesAsync()
    {
        var provinces = await _mediator.Send(new GetAllProvincesAsyncQuery());
        return Ok(provinces);
    }
}
