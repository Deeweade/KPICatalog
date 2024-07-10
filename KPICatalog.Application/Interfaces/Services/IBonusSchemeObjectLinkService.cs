using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeObjectLinkService
{
    Task<IEnumerable<BonusSchemeObjectLinkView>> BulkCreate(BonusSchemeObjectLinkView linkView);
    Task<IEnumerable<BonusSchemeObjectLinkView>> Delete(BonusSchemeObjectLinkView linkView);
}
