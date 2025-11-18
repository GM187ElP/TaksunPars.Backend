using Microsoft.AspNetCore.Mvc;
using TaksunPars.Application.Services;

namespace TaksunPars.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> Upload(int employeeId)
    {
        return Ok();
    }
}