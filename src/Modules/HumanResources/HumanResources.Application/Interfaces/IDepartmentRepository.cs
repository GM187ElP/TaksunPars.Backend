using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface IDepartmentRepository
{
    Task<ResultData<List<Department>>> GetAllDepartmentsAsync();
}
