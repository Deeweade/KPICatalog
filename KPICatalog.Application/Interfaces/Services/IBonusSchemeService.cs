using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeService
{
    Task<BonusSchemeView> GetById(int schemeId);
    Task<IEnumerable<string>> GetCostCenters();
    Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeQueryView filterView);
    Task<IEnumerable<BonusSchemeView>> GetByTypicalGoalId(int goalId);
    Task<BonusSchemeView> Create(BonusSchemeView schemeView);
    Task<BonusSchemeView> Update(BonusSchemeView schemeView);
    Task<BonusSchemeView> Deactivate(int bonusSchemeId, DateTime? dateEnd, int? newBonusSchemeId);
}
