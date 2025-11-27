namespace Shared.Interfaces;

public interface IEmployeeLookupService
{
    Task<Guid?> GetEmployeeIdByCodeAsync(string employeeCode, CancellationToken ct);
}
