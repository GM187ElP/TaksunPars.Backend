using ERP.Api.DTOs;
using ERP.Api.Services;
using HumanResources.Application.Interfaces;
using HumanResources.Infrastructure.Persistence;
using HumanResources.Infrastructure.Repositories;
using IAM.Application.DTOs;
using IAM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Payroll.Application.Common.Interfaces;
using Payroll.Domain.Interfaces;
using Payroll.Infrastructure.Parsing;
using Payroll.Infrastructure.Persistence;
using Payroll.Infrastructure.Repositories;
using Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register application services
//-----------------------------------------------------------------------------------------------

builder.Configuration.AddEnvironmentVariables();
string? passwordSalt = builder.Configuration["PasswordSalt"];
string? dbPass = builder.Configuration["NpgPassword"];
var jwtSettings = new JwtSettings
{
    Issuer = builder.Configuration["JwtIssuer"],
    Audience = builder.Configuration["JwtAudience"],
    Secret = builder.Configuration["JwtSecret"]
};

var dbData = new DbData
{
    // Local DB
    LocalHost = builder.Configuration["LocalDb_Host"],
    LocalUsername = builder.Configuration["LocalDb_Username"],
    LocalPassword = builder.Configuration["LocalDb_Password"],
    LocalDatabaseDev = builder.Configuration["LocalDb_Database_Dev"],
    LocalDatabaseProd = builder.Configuration["LocalDb_Database_Prod"],

    // Neon DB
    NeonHostDev = builder.Configuration["NeonDb_Host_Dev"],
    NeonHostProd = builder.Configuration["NeonDb_Host_Prod"],
    NeonUsername = builder.Configuration["NeonDb_Username"],
    NeonPasswordDev = builder.Configuration["NeonDb_Password_Dev"],
    NeonPasswordProd = builder.Configuration["NeonDb_Password_Prod"],
    NeonDatabase = builder.Configuration["NeonDb_Database"],
};

builder.Services.AddSingleton(passwordSalt);
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddSingleton(dbData);

var cs = DbConnectionStringFactory.BuildConnectionString(builder.Environment, dbData);

builder.Services.AddDbContext<HumanResourcesDbContext>(options =>
{
    options.UseNpgsql(cs.ToString());
});

builder.Services.AddDbContext<PayrollDbContext>(options =>
{
    options.UseNpgsql(cs.ToString());
});

builder.Services.AddDbContext<IAMDbContext>(options =>
{
    options.UseNpgsql(cs.ToString());
});

//-----------------------------------------------------------------------------------------------

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(HumanResources.Application.AssemblyMarker).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(IAM.Application.AssemblyMarker).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Payroll.Application.AssemblyMarker).Assembly);
});

builder.Services.AddScoped<IJobTitleRepository, JobTitleRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankNameRepository, BankNameRepository>();
builder.Services.AddScoped<IChequePromissionaryNoteRepository, ChequePromissionaryNoteRepository>();
builder.Services.AddScoped<ITrackJobTitleAndLeaveHistoryRepository, TrackJobTitleAndLeaveHistoryRepository>();


builder.Services.AddScoped<IEmployeeLookupService, EmployeeLookupService>();

builder.Services.AddScoped<IPayslipRepository, PayslipRepository>();
builder.Services.AddScoped<IExcelPayslipParser, ClosedXmlPayslipParser>();

//-----------------------------------------------------------------------------------------------
// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddAuthorization();


// Swagger / Swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});








var app = builder.Build();


// Middleware pipeline
app.UseCors();

// Swagger (order matters!)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// HTTPS
app.UseHttpsRedirection();

// Auth (keep even if no JWT yet)
app.UseAuthentication();
app.UseAuthorization();

//app.UseCors("AllowBlazor");
app.UseCors();
// Controllers
app.MapControllers();

// Run
app.Run();
