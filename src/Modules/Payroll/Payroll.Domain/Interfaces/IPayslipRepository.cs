using Payroll.Domain.Entities;
using Shared;

namespace Payroll.Domain.Interfaces;

public interface IPayslipRepository
{
    Task<ResultStatus> AddRangeAsync(Result<List<Payslip>> payslips, CancellationToken ct);
    Task<Result<Payslip>> GetPayslipByEmployeeCode(string employeeCode, int year, int month, CancellationToken ct);
}