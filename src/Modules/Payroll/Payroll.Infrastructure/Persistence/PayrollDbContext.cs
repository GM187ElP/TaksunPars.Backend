using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities;
using Payroll.Infrastructure.Persistence.Configurations;

namespace Payroll.Infrastructure.Persistence;

public class PayrollDbContext : DbContext
{
    public PayrollDbContext(DbContextOptions<PayrollDbContext> options):base(options)
    {
            
    }

    public DbSet<Payslip> Payslips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PayrollConfigurationsMarker).Assembly);
    }

}
