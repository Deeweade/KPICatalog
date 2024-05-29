using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain.Models.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeRepository
{
    Task<BonusScheme?> GetById(int schemeId);
    Task<IEnumerable<BonusScheme>> GetByFilter(BonusSchemesFilter filter);
}
