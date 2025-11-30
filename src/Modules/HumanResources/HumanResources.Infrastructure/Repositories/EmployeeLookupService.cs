using HumanResources.Application.Interfaces;
using Shared.DTOs;
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

    public async Task<Guid?> GetEmployeeIdByNationalIdAsync(string nationalId, CancellationToken ct)
    {
        return await _employeeRepository.GetEmployeeIdByNationalIdAsync(nationalId,ct);
    }

    public async Task<GetEmployeeNameDto> GetEmployeeNameByIdAsync(Guid id, CancellationToken ct)
    {
        var dto = new GetEmployeeNameDto();
        var result = await _employeeRepository.GetEmployeeByIdAsync(id, ct);
        dto.FirstName = result.FirstName ?? string.Empty;
        dto.LastName = result.LastName ?? string.Empty;

        return dto;
    }
}
