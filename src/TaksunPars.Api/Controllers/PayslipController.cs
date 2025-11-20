using Microsoft.AspNetCore.Mvc;
using TaksunPars.Application.Services;

namespace TaksunPars.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PayslipController : Controller
{
    private readonly ILogger<PayslipController> _logger;
    private readonly IPaySlipServices _paySlipServices;

    public PayslipController(ILogger<PayslipController> logger, IPaySlipServices paySlipServices)
    {
        _logger = logger;
        _paySlipServices = paySlipServices;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload( IFormFile payslipFile)
    {
        var result = await _paySlipServices.UploadAsync(payslipFile);
        return Ok(result);
    }
}