using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface IProvinceRepository
{
    Task<ResultData<List<Province>>> GetAllProvincesAsync(CancellationToken cancellationToken);
}
