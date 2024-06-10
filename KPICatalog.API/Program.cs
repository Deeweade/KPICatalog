using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Application.Services;
using KPICatalog.API.Middlewares;
using KPICatalog.Infrastructure;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using KPICatalog.Application.Models.Mappings;
using KPICatalog.Infrastructure.Models.Mappings;

#region EnvironmentConfiguring

var settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Settings");

var config = new ConfigurationBuilder()
    .SetBasePath(settingsPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

string machineName = Environment.MachineName.ToLower();

var machineNames = config.GetSection("EnvironmentMachines").Get<Dictionary<string, string>>();

string environment = machineNames.FirstOrDefault(x => x.Value.ToLower() == machineName).Key ?? "Test";

#endregion

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = environment,
    ContentRootPath = settingsPath
});

builder.Configuration
    .SetBasePath(settingsPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables();

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

#endregion

#region ContextConfiguring

string connectionString = builder.Configuration.GetConnectionString("KPICatalog");

if (builder.Environment.IsEnvironment("Development_opetrov2") || builder.Environment.IsEnvironment("Development_lmaksimova"))
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

#region DependenciesInjection

//services
builder.Services.AddScoped<IUserAccessControlService, UserAccessControlService>();
builder.Services.AddScoped<IBonusSchemeService, BonusSchemeService>();

//data
//builder.Services.AddScoped<IUserAccessControlRepository, UserAccessControlRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(InfrastructureMappingProfile), typeof(ApplicationMappingProfile));

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region ApplicationSettingUp

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsEnvironment("Development_opetrov2") || app.Environment.IsEnvironment("Development_lmaksimova"))
{
    app.UseMiddleware<DevAuthMiddleware>();
}

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapControllers();

#endregion

app.Run();