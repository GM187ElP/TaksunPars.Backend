using IAM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Persistence;

public class IAMDbContext : DbContext
{
    public IAMDbContext(DbContextOptions<IAMDbContext> options) : base(options)
    {

    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
