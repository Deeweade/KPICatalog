namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class RatingScaleValue : BaseEntity
{
    public int RatingScaleId { get; set; }
    public decimal? MinimumValue { get; set; }
    public decimal? MaximumValue { get; set; }
    public int RatingPercentage { get; set; }

    public virtual RatingScale RatingScale { get; set; }
}
