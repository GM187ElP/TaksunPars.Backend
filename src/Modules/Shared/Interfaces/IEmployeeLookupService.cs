using Shared.DTOs;

namespace Shared.Interfaces;

public interface IEmployeeLookupService
{
    Task<Guid?> GetEmployeeIdByCodeAsync(string employeeCode, CancellationToken ct);
    Task<Guid?> GetEmployeeIdByNationalIdAsync(string employeeCode, CancellationToken ct);
    Task<GetEmployeeNameDto> GetEmployeeNameByIdAsync(Guid id, CancellationToken ct);
}

