using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces;
using HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class JobTitleRepository : IJobTitleRepository
{
    private readonly HumanResourcesDbContext _db;

    public JobTitleRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public Task<ResultStatus> AddAsync(JobTitle jobTitle)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultData<List<JobTitle>>> GetAllJobTitlesByDepartment(Guid departmentId)
    {
        var result = new ResultData<List<JobTitle>>();

        result.Data = await _db.JobTitles
            .Where(jt => jt.DepartmentId == departmentId)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}
