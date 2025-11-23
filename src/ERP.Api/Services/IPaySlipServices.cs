using TaksunPars.Application.DTOs;
using TaksunPars.Core.Entities;

namespace ERP.Api.Services;

public interface IPayslipServices
{
    DownloadPayslipDto ToDto(Payslip p);
    byte[] PayslipPdfGenerate(DownloadPayslipDto dto);
}
