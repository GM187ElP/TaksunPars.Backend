using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<ResultStatus> AddAsync(Employee employee,CancellationToken cancellationToken);
    Task<Guid?> GetEmployeeIdByCodeAsync(string code, CancellationToken ct);
}
