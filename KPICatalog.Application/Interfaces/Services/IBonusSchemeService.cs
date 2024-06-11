using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeService
{
    Task<BonusSchemeView?> GetById(int schemeId);
    Task<IEnumerable<string>> GetCostCenters();
    Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeFilterView filterDto);
    Task<BonusSchemeView> Create(BonusSchemeView schemeDto);
    Task<BonusSchemeView> Update(BonusSchemeView schemeDto);
}
