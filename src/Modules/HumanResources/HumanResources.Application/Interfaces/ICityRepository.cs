using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface ICityRepository
{
    Task<ResultData<List<City>>> GetAllCitiesByProvinceAsync(Guid provinceId, CancellationToken cancellationToken);
}

