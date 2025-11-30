using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.Handlers.Commands.UploadPayslipsFromExcel;
using Payroll.Application.Handlers.Queries.GetPayslipByEmployeeCode;

namespace ERP.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PayslipController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<PayslipController> _logger;

    public PayslipController(ILogger<PayslipController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadAsync(IFormFile payslipFile)
    {
        if (payslipFile == null)
            return BadRequest("No file uploaded.");

        if (payslipFile.Length == 0)
            return BadRequest("Uploaded file is empty.");

        if (!payslipFile.FileName.EndsWith(".xlsx"))
            return BadRequest("Only .xlsx files are allowed.");

        await using var stream = payslipFile.OpenReadStream();

        var result = await _mediator.Send(new UploadPayslipsFromExcelCommand(stream));

        return Ok(result);
    }

    [HttpGet("get/{employeeCode}/{year}/{month}")]
    public async Task<IActionResult> GetPayslipByEmployeeCodeAsync(string employeeCode, int year, int month)
    {
        var code = employeeCode.Trim();

        if (code.Length != 5)
            return BadRequest("Employee code must be a five digit number");

        if (!int.TryParse(code, out _))
            return BadRequest($"Employee code '{code}' must contain only digits.");

        if (year < 1 || year > 9378)
            return BadRequest("Invalid year.");

        if (month < 1 || month > 12)
            return BadRequest("Invalid month.");

        var result = await _mediator.Send(new GetPayslipByEmployeeCodeQuery(code, year, month));

        return Ok(result);
    }


    //[Authorize]
    //[HttpGet("download/{personnelCode}/{year}/{month}")]
    //public async Task<IActionResult> Download(string personnelCode, string year, string month)
    //{
    //    var result = await _paySlipServices.DownloadAsync(personnelCode, int.Parse(year), int.Parse(month));

    //    if (!result.IsSuccess)
    //    {
    //        return NotFound(result);
    //    }

    //    var entity = (Payslip)result.Data!;
    //    var dto = _apiPayslipServices.ToDto(entity);

    //    return Ok(dto);
    //}



}