using HumanResources.Domain.Interfaces;
using Shared.Interfaces;

namespace HumanResources.Infrastructure.Repositories;

public class EmployeeLookupService : IEmployeeLookupService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeLookupService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Guid?> GetEmployeeIdByCodeAsync(string code, CancellationToken ct)
    {
        return await _employeeRepository.GetEmployeeIdByCodeAsync(code, ct);
    }
}
