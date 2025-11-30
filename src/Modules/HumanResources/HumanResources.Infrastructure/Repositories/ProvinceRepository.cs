using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class ProvinceRepository : IProvinceRepository
{
    private readonly HumanResourcesDbContext _db;

    public ProvinceRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public async Task<ResultData<List<Province>>> GetAllProvincesAsync(CancellationToken cancellationToken)
    {
        var result= new ResultData<List<Province>>();

        var provinces =await _db.Provinces.ToListAsync();

        result.Data=provinces;

        return result;
    }

}
