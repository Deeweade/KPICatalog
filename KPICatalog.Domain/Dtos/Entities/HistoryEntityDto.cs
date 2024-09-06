namespace KPICatalog.Domain.Dtos.Entities;

public abstract class HistoryEntityDto : BaseDto
{
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public bool IsActive { get; set; }
}
