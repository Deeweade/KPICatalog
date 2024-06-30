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
        TypicalGoalRepository = new TypicalGoalRepository(_kpiCatalogContext, mapper);
        TypicalGoalInBonusSchemeRepository = new TypicalGoalInBonusSchemeRepository(_kpiCatalogContext, mapper);
    }

    public IUserAccessControlRepository UserAccessControlRepository { get; }
    public IBonusSchemeRepository BonusSchemeRepository { get; }
    public IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public ITypicalGoalRepository TypicalGoalRepository { get; }
    public ITypicalGoalInBonusSchemeRepository TypicalGoalInBonusSchemeRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _kpiCatalogContext.SaveChangesAsync();
    }
}
