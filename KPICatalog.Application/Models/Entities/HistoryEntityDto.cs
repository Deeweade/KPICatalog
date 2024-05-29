namespace KPICatalog.Application.Models.Entities;

public abstract class HistoryEntityDto : BaseEntityDto
{
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public bool IsActive { get; set; }
}
