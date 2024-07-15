using KPICatalog.Application.Models.Views;

namespace KPICatalog.API.Models.Other;

public class TypicalGoalsInBSBulkUpdateView
{
    public ICollection<int> EntitiesIds { get; set; }
    public TypicalGoalInBonusSchemeView TypicalGoalInBS { get; set; }
}
