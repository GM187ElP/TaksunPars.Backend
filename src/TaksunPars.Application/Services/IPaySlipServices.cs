using Microsoft.AspNetCore.Http;
using Shared;
using TaksunPars.Core.Entities;

namespace TaksunPars.Application.Services;

public interface IPaySlipServices
{
    Task<Result<List<Payslip>>> UploadAsync(IFormFile paySlipFile);

    //Task<Result<List<Payslip>>> DownloadAsync(string personnelCode, int year, int month);
}