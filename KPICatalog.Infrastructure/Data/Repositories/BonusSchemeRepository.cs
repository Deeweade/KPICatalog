using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain.Models.Filters;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure;

public class BonusSchemeRepository : IBonusSchemeRepository
{
    private readonly KPICatalogDbContext _context;

    public BonusSchemeRepository(KPICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<BonusScheme?> GetById(int schemeId)
    {
        if (schemeId <= 0) throw new ArgumentOutOfRangeException(nameof(schemeId));

        return await _context.BonusSchemes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == schemeId);
    }

    public async Task<IEnumerable<BonusScheme>> GetByFilter(BonusSchemesFilter filter)
    {
        if (filter is null) throw new ArgumentNullException(nameof(filter));

        var query = _context.BonusSchemes.AsNoTracking();

        if (filter.IncludeActiveOnly is not null)
        {
            query = query.Where(x => x.IsActive);
        }

        return await query.ToListAsync();
    }
}
