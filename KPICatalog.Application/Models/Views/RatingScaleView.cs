namespace KPICatalog.Application.Models.Views;

public class RatingScaleView : BaseView
{
    public string Name { get; set; }

    public List<RatingScaleValueView> Values { get; set; }
}
