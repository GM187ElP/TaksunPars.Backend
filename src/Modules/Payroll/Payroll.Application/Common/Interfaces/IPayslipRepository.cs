using Payroll.Domain.Entities;
using Shared;

namespace Payroll.Application.Common.Interfaces;

public interface IPayslipRepository
{
    Task<ResultStatus> AddRangeAsync(Result<List<Payslip>> payslips, CancellationToken ct);
    Task<Payslip?> GetPayslipByEmployeeCode(string employeeCode, string year, string month, CancellationToken ct);
}