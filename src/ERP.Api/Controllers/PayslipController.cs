using ERP.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using TaksunPars.Application.DTOs;
using TaksunPars.Application.Services;
using TaksunPars.Core.Entities;

namespace ERP.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PayslipController : Controller
{
    private readonly IPaySlipServices _paySlipServices;
    private readonly IPayslipServices _apiPayslipServices;
    private readonly ILogger<PayslipController> _logger;

    public PayslipController(ILogger<PayslipController> logger, IPaySlipServices paySlipServices,
        IPayslipServices apiPayslipServices
        )
    {
        _logger = logger;
        _paySlipServices = paySlipServices;
        _apiPayslipServices = apiPayslipServices;
    }

    [Authorize]
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(IFormFile payslipFile)
    {
        var result = await _paySlipServices.UploadAsync(payslipFile);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("download/{personnelCode}/{year}/{month}")]
    public async Task<IActionResult> Download(string personnelCode, string year, string month)
    {
        var result = await _paySlipServices.DownloadAsync(personnelCode, int.Parse(year),int.Parse( month));

        if (!result.IsSuccess)
        {
            return NotFound(result);
        }

        var entity = (Payslip)result.Data!;
        var dto = _apiPayslipServices.ToDto(entity);

        return Ok(dto);
    }

    [Authorize]
    [HttpPost("GetPdf")]
    public IActionResult GetPdf([FromBody] DownloadPayslipDto dto)
    {
        var bytes = _apiPayslipServices.PayslipPdfGenerate(dto);

        var filename = $"Payslip_{dto.PersonnelCode}_{dto.Year}_{dto.Month}.pdf";

        return File(bytes, "application/pdf", filename);
    }


}