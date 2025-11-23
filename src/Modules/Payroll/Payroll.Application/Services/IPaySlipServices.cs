using Microsoft.AspNetCore.Http;
using TaksunPars.Shared;

namespace Payroll.Application.Services;

public interface IPaySlipServices
{
    Task<Result> UploadAsync(IFormFile paySlipFile);

    Task<Result> DownloadAsync(string personnelCode, int year, int month);
}