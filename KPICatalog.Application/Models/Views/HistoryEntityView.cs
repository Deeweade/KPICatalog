namespace KPICatalog.Application.Models.Views;

public abstract class HistoryEntityView : BaseView
{
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public bool IsActive { get; set; }
}
