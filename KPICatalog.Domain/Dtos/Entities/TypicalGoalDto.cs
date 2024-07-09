namespace KPICatalog.Domain.Dtos.Entities;

public class TypicalGoalDto : BaseEntityDto
{
    public string Title { get; set; }
    public int PlanningCycleId { get; set; }
    public int WeightTypeId { get; set; }
    public int ParentGoalId { get; set; }
    public string ExternalId { get; set; }
}