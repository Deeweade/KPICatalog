using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeObjectLinkService
{
    Task<List<BonusSchemeObjectLinkView>> GetByQuery(BonusSchemeObjectLinkQueryView view);
    Task<IEnumerable<BonusSchemeObjectLinkView>> BulkCreate(BonusSchemeObjectLinkView linkView);
    Task<IEnumerable<BonusSchemeObjectLinkView>> Delete(BonusSchemeObjectLinkView linkView);
}
