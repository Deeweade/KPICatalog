using System.ComponentModel.DataAnnotations.Schema;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("RatingScaleValue")]
public class RatingScaleValue : BaseEntity
{
    public int? RatingScaleId { get; set; }
    public decimal? MinimumValue { get; set; }
    public decimal? MaximumValue { get; set; }
    public int? RatingPercentage { get; set; }
}
