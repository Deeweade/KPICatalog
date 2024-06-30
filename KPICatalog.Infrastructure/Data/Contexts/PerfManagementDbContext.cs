using KPICatalog.Domain.Models.Entities.Goals;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Contexts;

public class PerfManagementDbContext : DbContext
{
    public PerfManagementDbContext(DbContextOptions<PerfManagementDbContext> options)
    : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Period> Periods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<Employee>();
        modelBuilder.Ignore<Period>();
    }
}
