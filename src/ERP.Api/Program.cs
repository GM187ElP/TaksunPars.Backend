using ERP.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Npgsql;
using QuestPDF.Infrastructure;
using System.Text;
using TaksunPars.Application.Services;
using TaksunPars.Infrastructure.Data;
using TaksunPars.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register application services
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IPaySlipServices, PaySlipServices>();
builder.Services.AddScoped<IPersonnelServices, PersonnelServices>();
builder.Services.AddScoped<IPayslipServices, TaksunPars.Api.Services.PayslipServices>();
QuestPDF.Settings.License = LicenseType.Community;


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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        },
            SecurityAlgorithms.HmacSha256
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

builder.Services.AddDbContext<AppDbContext>(options =>
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
