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
    }

    public IUserAccessControlRepository UserAccessControlRepository { get; set; }
    public IBonusSchemeRepository BonusSchemeRepository { get; set; }
    public IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; set; }
    public IEmlpoyeeRepository EmployeeRepository { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await _kpiCatalogContext.SaveChangesAsync();
    }
}
