using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Persistence;

public class HumanResourcesDbContext : DbContext
{
    public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options) : base(options)
    {

    }

    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankName> BankNames { get; set; }
    public DbSet<ChequePromissionaryNote> ChequePromissionaryNotes { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<TrackJobTitleAndLeaveHistory> StartLeaveHistories { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Department> Departments { get; set; }
}
