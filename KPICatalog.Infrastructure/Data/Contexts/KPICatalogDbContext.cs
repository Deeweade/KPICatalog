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
    public DbSet<EvaluationMethod> EvaluationMethods { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TypicalGoalInBonusScheme>()
            .Property(p => p.Plan)
            .HasPrecision(18, 3);

        modelBuilder.Entity<TypicalGoalInBonusScheme>()
            .Property(p => p.Fact)
            .HasPrecision(18, 3);

        modelBuilder.Entity<TypicalGoalInBonusScheme>()
            .Property(p => p.Evaluation)
            .HasPrecision(18, 3);

        modelBuilder.Entity<TypicalGoalInBonusScheme>()
            .Property(p => p.Weight)
            .HasPrecision(18, 3);

        Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaluationMethod>().HasData(
            new EvaluationMethod { Id = 1, Name = "Прямой" },
            new EvaluationMethod { Id = 2, Name = "Обратно-пропорциональный" },
            new EvaluationMethod { Id = 3, Name = "Шкала SLA" }
        );

        modelBuilder.Entity<LinkedObjectType>().HasData(
            new LinkedObjectType { Id = 1, Name = "BS-Employee" },
            new LinkedObjectType { Id = 2, Name = "BS-Goal" },
            new LinkedObjectType { Id = 3, Name = "BS-Request" },
            new LinkedObjectType { Id = 4, Name = "BS-Group" }
        );

        modelBuilder.Entity<BonusSchemeLinkMethod>().HasData(
            new BonusSchemeLinkMethod { Id = 1, Name = "На сотрудника" },
            new BonusSchemeLinkMethod { Id = 2, Name = "На бонусную схему" },
            new BonusSchemeLinkMethod { Id = 3, Name = "На всех" }
        );

        modelBuilder.Entity<PlanningCycle>().HasData(
            new PlanningCycle { Id = 1, Name = "Годовая цель" },
            new PlanningCycle { Id = 2, Name = "ЛОКР" },
            new PlanningCycle { Id = 3, Name = "Критерий достижения" },
            new PlanningCycle { Id = 4, Name = "Квартальная цель" },
            new PlanningCycle { Id = 5, Name = "Месячная цель" }
        );

        modelBuilder.Entity<WeightType>().HasData(
            new WeightType { Id = 1, Name = "Процент" },
            new WeightType { Id = 2, Name = "Тариф" },
            new WeightType { Id = 3, Name = "Комиссия" }
        );
    }
}
