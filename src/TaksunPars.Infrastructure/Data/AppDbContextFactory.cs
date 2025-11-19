using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace TaksunPars.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TaksunPars.Api"))
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile("Private/secrets.json", false)
            .Build();

        // Build connection string with explicit null check
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

        var cs = new NpgsqlConnectionStringBuilder(connectionString!);
        cs.Password = configuration["secrets:Password"];

        // Create DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(cs.ToString());

        return new AppDbContext(optionsBuilder.Options);
    }
}