using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities;
using Payroll.Domain.Interfaces;
using Payroll.Infrastructure.Persistence;
using Shared;
using Shared.Interfaces;

namespace Payroll.Infrastructure.Repositories;

public class PayslipRepository : IPayslipRepository
{
    private readonly PayrollDbContext _db;
    private readonly IEmployeeLookupService _employeeLookupService;


    public PayslipRepository(PayrollDbContext dbContext, IEmployeeLookupService employeeLookupService)
    {
        _db = dbContext;
        _employeeLookupService = employeeLookupService;
    }

    public async Task<ResultStatus> AddRangeAsync(Result<List<Payslip>> payslips, CancellationToken ct)
    {
        foreach (var p in payslips.Data.Data)
        {
            var employeeId = await _employeeLookupService.GetEmployeeIdByCodeAsync(p.EmployeeCode, ct);

            if (employeeId == null || employeeId == Guid.Empty)
            {
                payslips.Status.Errors.Add($"Employee not found: {p.EmployeeCode}");
                continue;
            }

            p.EmployeeId = employeeId.Value;

            var existing = await _db.Payslips
                .FirstOrDefaultAsync(x =>
                    x.EmployeeCode == p.EmployeeCode &&
                    x.Year == p.Year &&
                    x.Month == p.Month, ct);

            if (existing != null)
            {
                _db.Payslips.Remove(existing);
            }

            _db.Payslips.Add(p);
        }

        var changesCount = await _db.SaveChangesAsync(ct);

        if (changesCount > 0)
            payslips.Status.IsPartialySuccess = true;
        else
            payslips.Status.IsPartialySuccess = false;

        return payslips.Status;
    }

    public async Task<Result<Payslip>> GetPayslipByEmployeeCode(string employeeCode, int year, int month, CancellationToken ct)
    {
        Result<Payslip> result = new();

        var payslip = await _db.Payslips
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmployeeCode == employeeCode && x.Year == year.ToString() && x.Month == month.ToString(), ct);

        if (payslip != null)
        {
            result.Data.Data = payslip; 
            result.Status.IsPartialySuccess = true;
        }
        else
        {
            result.Status.Errors.Add($"Payslip not found for {employeeCode} in {month}/{year}.");
            result.Status.IsPartialySuccess = false;  
        }

        return result;
    }

}
