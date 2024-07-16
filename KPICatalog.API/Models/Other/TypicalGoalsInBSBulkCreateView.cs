using KPICatalog.Application.Models.Views;

namespace KPICatalog.API.Models.Other;

public class TypicalGoalsInBSBulkCreateView
{
    public ICollection<int> BonusSchemesIds { get; set; }
    public ICollection<TypicalGoalView> TypicalGoals { get; set; }
}
