namespace KPICatalog.Application.Models.Views;

public class CalculateEvaluationView
{
    public decimal Plan { get; set; }
    public decimal Fact { get; set; }
    public int EvaluationMethodId { get; set; }
    public int? RatingScaleId { get; set; }
}
