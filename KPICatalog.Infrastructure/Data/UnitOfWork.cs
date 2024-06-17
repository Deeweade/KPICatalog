using KPICatalog.Infrastructure.Data.Repositories;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using AutoMapper;

namespace KPICatalog.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly KPICatalogDbContext _context;

    public UnitOfWork(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;

        UserAccessControlRepository = new UserAccessControlRepository(_context, mapper);
        BonusSchemeRepository = new BonusSchemeRepository(_context, mapper);
        BonusSchemeObjectLinkRepository = new BonusSchemeObjectLinkRepository(_context, mapper);
        EmployeeRepository = new EmployeeRepository(_context, mapper);
        TypicalGoalRepository = new TypicalGoalRepository(_context, mapper);
    }

    public IUserAccessControlRepository UserAccessControlRepository { get; set; }
    public IBonusSchemeRepository BonusSchemeRepository { get; set; }
    public IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; set; }
    public IEmlpoyeeRepository EmployeeRepository { get; set; }
    public ITypicalGoalRepository TypicalGoalRepository { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
