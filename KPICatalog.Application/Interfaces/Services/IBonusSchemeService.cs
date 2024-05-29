using KPICatalog.Application.Models.Entities;
using KPICatalog.Application.Models.Filters;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeService
{
    Task<BonusSchemeView?> GetById(int schemeId);
    Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeFilterView filterDto);
    Task<BonusSchemeView> Create(BonusSchemeView schemeDto);
    Task<BonusSchemeView> Update(BonusSchemeView schemeDto);
}
