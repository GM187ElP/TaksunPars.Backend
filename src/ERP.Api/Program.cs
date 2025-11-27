using HumanResources.Domain.Interfaces;
using HumanResources.Infrastructure.Persistence;
using HumanResources.Infrastructure.Repositories;
using IAM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Npgsql;
using Payroll.Application.Common.Interfaces;
using Payroll.Domain.Interfaces;
using Payroll.Infrastructure.Parsing;
using Payroll.Infrastructure.Persistence;
using Payroll.Infrastructure.Repositories;
using Shared.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register application services


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

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,

            ValidIssuer = "Issuer",
            ValidAudience = "Audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowBlazor",
//        policy =>
//        {
//            policy.AllowAnyOrigin()
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});

// Secrets for development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile(
        Path.Combine("Private", "secrets.json"),
        optional: false,
        reloadOnChange: true
    );
}

// Swagger / Swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json");

var dbPassword = builder.Configuration["secrets:Password"]
    ?? throw new InvalidOperationException("Database password not found. Check Private/secrets.json");

Console.WriteLine($"✅ Password loaded successfully: {dbPassword.Length} characters");

var cs = new NpgsqlConnectionStringBuilder(connectionString)
{
    Password = dbPassword
};

Console.WriteLine(
    $"✅ Connection string built: Host={cs.Host}, Database={cs.Database}, Username={cs.Username}, PasswordSet={(!string.IsNullOrEmpty(cs.Password))}"
);

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
