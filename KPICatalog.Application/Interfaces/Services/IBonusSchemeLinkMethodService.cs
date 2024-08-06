using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeLinkMethodService
{
    Task<List<BonusSchemeLinkMethodView>> GetAll();
}
