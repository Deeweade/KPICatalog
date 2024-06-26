using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Contexts;

public class KPICatalogDbContext : DbContext
{
    public KPICatalogDbContext(DbContextOptions<KPICatalogDbContext> options)
        : base(options)
    {
        //InitializeLinkedObjectTypes(); - 1 вариант с массивом

        /* if (LinkedObjectTypes.Any())
        {
            var linkedObjectTypes = Enum.GetValues(typeof(LinkedObjectTypes))
                                        .Cast<LinkedObjectTypes>()
                                        .Select(e => new LinkedObjectType { Name = e.ToString() })
                                        .ToList();

            LinkedObjectTypes.AddRange(linkedObjectTypes);
            SaveChanges();
        } */ // - 2 вариант со словарем, но не уверена насчет корректности названий связей
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
    /* public void InitializeLinkedObjectTypes()
    {
        var requiredNames = new[] { "BS-Employee", "BS-TypicalGoal" };
        var existingNames = LinkedObjectTypes
            .Where(x => requiredNames.Contains(x.Name))
            .Select(x => x.Name)
            .ToList();

        foreach (var name in requiredNames.Except(existingNames))
        {
            LinkedObjectTypes.Add(new LinkedObjectType { Name = name });
        }

        if (ChangeTracker.HasChanges())
        {
            SaveChanges();
        }
    } */
}
