using HumanResources.Application.Handlers.Queries.Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllDepartmentsAsync()
    {
        var departments = await _mediator.Send(new GetAllDepartmentsAsyncQuery());
        return Ok(departments);
    }
}
