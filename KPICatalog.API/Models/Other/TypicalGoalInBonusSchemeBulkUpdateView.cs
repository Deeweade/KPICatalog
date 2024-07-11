using KPICatalog.Application.Models.Views;

namespace KPICatalog.API;

public class TypicalGoalInBonusSchemeBulkUpdateView
{
    public ICollection<int> EntitiesIds { get; set; }
    public TypicalGoalInBonusSchemeView TypicalGoalInBS { get; set; }
}
