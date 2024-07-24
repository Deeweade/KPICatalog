using KPICatalog.Infrastructure.Data.Repositories;
using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Models.Mappings;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Application.Models.Mappings;
using KPICatalog.Application.Services;
using KPICatalog.API.Models.Mappings;
using KPICatalog.API.Middlewares;
using KPICatalog.Infrastructure;
using KPICatalog.API.Utilities;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

#region EnvironmentConfiguring

var settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Settings");

var config = new ConfigurationBuilder()
    .SetBasePath(settingsPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string machineName = Environment.MachineName.ToLower();

var machineNames = config.GetSection("EnvironmentMachines").Get<Dictionary<string, string>>();

string environment = machineNames.FirstOrDefault(x => x.Value.ToLower() == machineName).Key ?? "Development";


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

// Регистрация ApiSettings в контейнере DI
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));


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
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

#endregion

#region ContextsConfiguring

string kpiCatalogConnectionString = builder.Configuration.GetConnectionString("KPICatalog");

var perfManagementConnectionString = builder.Configuration.GetConnectionString("PerfManagement1");

if (environment.ToLower().Equals("development"))
{
    kpiCatalogConnectionString = kpiCatalogConnectionString.Replace("sqlserver", "localhost");
    perfManagementConnectionString = perfManagementConnectionString.Replace("sqlserver", "localhost");
}

builder.Services.AddDbContext<KPICatalogDbContext>(options =>
    options.UseSqlServer(kpiCatalogConnectionString, b => b.MigrationsAssembly("KPICatalog.API")));

builder.Services.AddDbContext<PerfManagementDbContext>(options =>
    options.UseSqlServer(perfManagementConnectionString));

#endregion

#region DependenciesInjection

//services
builder.Services.AddScoped<IUserAccessControlService, UserAccessControlService>();
builder.Services.AddScoped<IBonusSchemeService, BonusSchemeService>();
builder.Services.AddScoped<IBonusSchemeObjectLinkService, BonusSchemeObjectLinkService>();
builder.Services.AddScoped<ITypicalGoalService, TypicalGoalService>();
builder.Services.AddScoped<ITypicalGoalInBonusSchemeService, TypicalGoalInBonusSchemeService>();
builder.Services.AddScoped<IEvaluationCalculator, EvaluationCalculator>();

//repositories
builder.Services.AddScoped<IRatingScaleValuesRepository, RatingScaleValuesRepository>();

builder.Services.AddHttpClient<ApiClient>();

//data
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(InfrastructureMappingProfile), typeof(ApplicationMappingProfile), typeof(APIMappings));

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "KPICatalog API", Version = "v1" });
});

var app = builder.Build();

#region ApplicationSettingUp

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

#region RunMigrations

//Запуск миграций при старте приложения
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<KPICatalogDbContext>();
    dbContext.Database.Migrate();
}

#endregion

app.Run();