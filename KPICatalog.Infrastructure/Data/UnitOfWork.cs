using KPICatalog.Infrastructure.Data.Repositories;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;

namespace KPICatalog.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly KPICatalogDbContext _context;

    public UnitOfWork(KPICatalogDbContext context)
    {
        _context = context;

        UserAccessControlRepository = new UserAccessControlRepository(_context);
        BonusSchemeRepository = new BonusSchemeRepository(_context);
    }

    public IUserAccessControlRepository UserAccessControlRepository { get; set; }
    public IBonusSchemeRepository BonusSchemeRepository { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
