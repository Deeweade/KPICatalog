namespace KPICatalog.API.Models.Other;

public class BulkEvaluateView
{
    public ICollection<int> TypicalGoalsInBSIds { get; set; }
    public decimal Fact { get; set; }
}
