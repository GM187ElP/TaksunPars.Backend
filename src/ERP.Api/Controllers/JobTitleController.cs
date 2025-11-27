using HumanResources.Application.Handlers.Queries.JobTitle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class JobTitleController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobTitleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ByDepartment/{Id}")]
    public async Task<IActionResult> GetJobTitlesByDepartment(Guid Id)
    {
        var departmentJobTitles = await _mediator.Send(new GetAllJobTitlesByDepartmentAsyncQuery(Id));

        return Ok(departmentJobTitles);
    }
}
