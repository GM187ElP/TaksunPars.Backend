using Payroll.Domain.Entities;
using Payroll.Domain.Interfaces;
using Payroll.Infrastructure.Persistence;

namespace Payroll.Infrastructure.Repositories;

public class PayslipRepository: IPayslipRepository
{
    private readonly PayrollDbContext _dbContext;

    public PayslipRepository(PayrollDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddRangeAsync(IEnumerable<Payslip> payslips, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
