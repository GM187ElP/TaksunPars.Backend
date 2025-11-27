using HumanResources.Application.DTOs;
using HumanResources.Application.Handlers.Commands.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromForm] AddEmployeeDto dto)
    {
        var result = await _mediator.Send(new EmployeeAddAsyncCommand(dto));

        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}
