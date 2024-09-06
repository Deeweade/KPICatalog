namespace KPICatalog.Domain.Dtos.Entities;

public class RatingScaleValueDto : BaseDto
{
    public int RatingScaleId { get; set; }
    public decimal? MinimumValue { get; set; }
    public decimal? MaximumValue { get; set; }
    public int RatingPercentage { get; set; }
}
