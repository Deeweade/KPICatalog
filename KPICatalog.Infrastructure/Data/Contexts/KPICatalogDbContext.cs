using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Contexts;

public class KPICatalogDbContext : DbContext
{
    public KPICatalogDbContext(DbContextOptions<KPICatalogDbContext> options)
        : base(options)
    {
    }

    //tables
    public DbSet<UserAccessControl> UserAccessControls { get; set; }
    public DbSet<BonusScheme> BonusSchemes { get; set; }
    public DbSet<BonusSchemeObjectLink> BonusSchemeObjectLinks { get; set; }

    //views
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
