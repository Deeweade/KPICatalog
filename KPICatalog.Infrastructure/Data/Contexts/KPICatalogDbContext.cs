using KPICatalog.Domain.Models.Entities.KPICatalog;
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
    public DbSet<TypicalGoal> TypicalGoals { get; set; }
    public DbSet<TypicalGoalInBonusScheme> TypicalGoalInBonusSchemes { get; set; }
    public DbSet<LinkedObjectType> LinkedObjectTypes { get; set; }
    public DbSet<PlanningCycle> PlanningCycles { get; set; }
    public DbSet<WeightType> WeightTypes { get; set; }
    public DbSet<BonusSchemeLinkMethod> BonusSchemeLinkMethod { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
