using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly HumanResourcesDbContext _db;

    public DepartmentRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public async Task<ResultData<List<Department>>> GetAllDepartmentsAsync()
    {
        var result= new ResultData<List<Department>>();

        result.Data=await _db.Departments.AsNoTracking()
            .ToListAsync();

        return result;
    }
}
