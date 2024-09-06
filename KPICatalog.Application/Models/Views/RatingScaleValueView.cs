namespace KPICatalog.Application.Models.Views;

public class RatingScaleValueView : BaseView
{
    public int RatingScaleId { get; set; }
    public decimal? MinimumValue { get; set; }
    public decimal? MaximumValue { get; set; }
    public int RatingPercentage { get; set; }
}
