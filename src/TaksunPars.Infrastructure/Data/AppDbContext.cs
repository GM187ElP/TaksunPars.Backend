using Microsoft.EntityFrameworkCore;
using TaksunPars.Core.Entities;
using TaksunPars.Infrastructure.Configurations;

namespace TaksunPars.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Personnel> Personnel { get; set; }
    public DbSet<Payslip> Payslips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new PersonnelConfiguration());
        modelBuilder.ApplyConfiguration(new PaySlipConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}