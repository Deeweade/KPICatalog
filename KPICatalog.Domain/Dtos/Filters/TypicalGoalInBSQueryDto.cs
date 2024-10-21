namespace KPICatalog.Domain.Dtos.Filters;

public class TypicalGoalInBSQueryDto
{
    public int? TypicalGoalId { get; set; }
    public List<int> Ids { get; set; }
    public List<int> PeriodIds { get; set; }
}
