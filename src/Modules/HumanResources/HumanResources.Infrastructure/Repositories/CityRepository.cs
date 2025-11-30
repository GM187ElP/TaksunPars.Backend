using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly HumanResourcesDbContext _db;

    public CityRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public async Task<ResultData<List<City>>> GetAllCitiesByProvinceAsync(Guid provinceId, CancellationToken cancellationToken)
    {
        var result = new ResultData<List<City>>();

        var cities = await _db.Cities.Where(c => c.ProvinceId == provinceId)
            .AsNoTracking()
            .ToListAsync();

        result.Data = cities;
        return result;
    }
}
