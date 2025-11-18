using Microsoft.AspNetCore.Http;
using TaksunPars.Shared;

namespace TaksunPars.Application.Services;

public interface IPaySlipServices
{
    Task<Result> UploadAsync(IFormFile paySlipFile);
}