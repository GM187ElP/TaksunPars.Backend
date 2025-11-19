using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaksunPars.Application.Services;
using TaksunPars.Infrastructure.Data;
using TaksunPars.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// In Program.cs
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IPaySlipServices, PaySlipServices>();
builder.Services.AddScoped<IPersonnelServices, PersonnelServices>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

if (builder.Environment.IsDevelopment())
    builder.Configuration.AddJsonFile(
        Path.Combine("Private", "secrets.json"),
        false,
        true
    );

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json");

var dbPassword = builder.Configuration["secrets:Password"];
if (string.IsNullOrEmpty(dbPassword))
    throw new InvalidOperationException(
        "Database password not found. Check Private/secrets.json exists and contains 'secrets:Password'");

Console.WriteLine($"✅ Password loaded successfully: {dbPassword.Length} characters");

var cs = new NpgsqlConnectionStringBuilder(connectionString);
cs.Password = dbPassword;

Console.WriteLine(
    $"✅ Connection string built: Host={cs.Host}, Database={cs.Database}, Username={cs.Username}, PasswordSet={!string.IsNullOrEmpty(cs.Password)}");

builder.Services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(cs.ToString()); });


var app = builder.Build();

// Enable CORS
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();