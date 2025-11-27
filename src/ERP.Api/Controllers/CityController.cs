using HumanResources.Application.Handlers.Queries.City;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ByProvince/{Id}")]
    public async Task<IActionResult> GetCitiesByProvince(Guid Id)
    {
        var provinceCities = await _mediator.Send(new GetAllCitiesByProvinceAsyncQuery(Id));
        return Ok(provinceCities);
    }
}
