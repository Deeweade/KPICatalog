using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Application.Services;
using KPICatalog.Application;
using KPICatalog.API;
using System.Text.Json.Serialization;
using KPICatalog.Domain;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region EnvironmentConfiguring

builder.Configuration
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Settings"))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

string machineName = Environment.MachineName.ToLower();

var machineNames = builder.Configuration.GetSection("EnvironmentMachines").Get<Dictionary<string, string>>();

string environment = machineNames.FirstOrDefault(x => x.Value.ToLower() == machineName).Key ?? "Test";

builder.Host.UseEnvironment(environment);

// Перезагружаем конфигурацию для нового окружения
builder.Configuration
    .AddJsonFile($"appsettings.{environment}.json", optional: true);

#endregion

#region AuthenticationConfiguring
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

#endregion

#region ControllersConfiguring
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region ContextConfiguring

string connectionString = builder.Configuration.GetConnectionString("KPICatalog");

if (builder.Environment.IsEnvironment("Development_opetrov2"))
{
    builder.Services.AddDbContext<KPICatalogDbContext>(options =>
        options.UseNpgsql(connectionString, b => b.MigrationsAssembly("KPICatalog.API")));
}
else if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<KPICatalogDbContext>(options =>
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("KPICatalog.API")));
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<KPICatalogDbContext>(options =>
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("KPICatalog.API")));
}

#endregion

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

#region DependenciesInjection

//services
builder.Services.AddScoped<IUserAccessControlService, UserAccessControlService>();

//data
//builder.Services.AddScoped<IUserAccessControlRepository, UserAccessControlRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();

if (app.Environment.IsEnvironment("Development_opetrov2"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();