using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<ResultData<List<Department>>> GetAllDepartmentsAsync();
}
