using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    //[Authorize]
    //[HttpPost("upload")]
    //[Consumes("multipart/form-data")]
    //public async Task<IActionResult> Upload(IFormFile payslipFile)
    //{
    //    var result = await _paySlipServices.UploadAsync(payslipFile);
    //    return Ok(result);
    //}

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