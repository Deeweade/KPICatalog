using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeService
{
    Task<BonusSchemeView?> GetById(int schemeId);
    Task<IEnumerable<string>> GetCostCenters();
    Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeFilterView filterView);
    Task<BonusSchemeView?> Create(BonusSchemeView schemeView);
    Task<BonusSchemeView?> Update(BonusSchemeView schemeView);
    Task<BonusSchemeView?> Deactivate(int bonusSchemeId, DateTime dateEnd, int? newBonusSchemeId);
}
