using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<ResultStatus> AddAsync(Employee employee,CancellationToken cancellationToken);
    Task<Guid?> GetEmployeeIdByCodeAsync(string code, CancellationToken cancellationToken);
    Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid?> GetEmployeeIdByNationalIdAsync(string nationalId,CancellationToken cancellationToken);
}
