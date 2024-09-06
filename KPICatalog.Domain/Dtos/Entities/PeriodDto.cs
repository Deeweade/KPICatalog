namespace KPICatalog.Domain.Dtos.Entities;

public class PeriodDto : BaseDto
{
    public string Title { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int? NumberY { get; set; }
    public int? NumberQ { get; set; }
    public int IsYear { get; set; }
}
