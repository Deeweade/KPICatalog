using KPICatalog.Infrastructure.Data.Repositories;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using AutoMapper;

namespace KPICatalog.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly KPICatalogDbContext _kpiCatalogContext;

    public UnitOfWork(KPICatalogDbContext kpiCatalogContext, IMapper mapper, PerfManagementDbContext perfManagementContext)
    {
        _kpiCatalogContext = kpiCatalogContext;

        UserAccessControlRepository = new UserAccessControlRepository(_kpiCatalogContext, mapper);
        BonusSchemeRepository = new BonusSchemeRepository(_kpiCatalogContext, mapper);
        BonusSchemeObjectLinkRepository = new BonusSchemeObjectLinkRepository(_kpiCatalogContext, mapper);
        EmployeeRepository = new EmployeeRepository(perfManagementContext, mapper);
        PeriodsRepository = new PeriodsRepository(perfManagementContext, mapper);
        TypicalGoalRepository = new TypicalGoalRepository(_kpiCatalogContext, mapper);
        TypicalGoalInBonusSchemeRepository = new TypicalGoalInBonusSchemeRepository(_kpiCatalogContext, mapper);
        WeightTypesRepository = new WeightTypesRepository(_kpiCatalogContext, mapper);
        BonusSchemeLinkMethodRepository = new BonusSchemeLinkMethodRepository(_kpiCatalogContext, mapper);
        PlanningCyclesRepository = new PlanningCyclesRepository(_kpiCatalogContext, mapper);
        EvaluationMethodsRepository = new EvaluationMethodsRepository(_kpiCatalogContext, mapper);
    }

    public IUserAccessControlRepository UserAccessControlRepository { get; }
    public IBonusSchemeRepository BonusSchemeRepository { get; }
    public IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; }
    public ITypicalGoalRepository TypicalGoalRepository { get; }
    public ITypicalGoalInBonusSchemeRepository TypicalGoalInBonusSchemeRepository { get; }
    public IWeightTypesRepository WeightTypesRepository { get; }
    public IBonusSchemeLinkMethodRepository BonusSchemeLinkMethodRepository { get; }
    public IPlanningCyclesRepository PlanningCyclesRepository { get; }
    public IEvaluationMethodsRepository EvaluationMethodsRepository { get; }

    public IEmployeeRepository EmployeeRepository { get; }
    public IPeriodsRepository PeriodsRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _kpiCatalogContext.SaveChangesAsync();
    }
}
