using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface IJobTitleRepository
{
    Task<ResultData<List<JobTitle>>> GetAllJobTitlesByDepartment(Guid departmentId);
    Task<ResultStatus> AddAsync(JobTitle jobTitle);
}
