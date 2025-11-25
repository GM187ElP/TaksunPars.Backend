using Payroll.Domain.Entities;
using Shared;

namespace Payroll.Domain.Interfaces;

public interface IPayslipRepository
{
    //Task AddAsync(Payslip payslip, CancellationToken ct);
    Task AddRangeAsync(Result<List<Payslip>> payslips, CancellationToken ct);
    //Task<Payslip?> GetByIdAsync(Guid id, CancellationToken ct);
}