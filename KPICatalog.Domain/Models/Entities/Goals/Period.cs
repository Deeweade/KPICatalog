using System.ComponentModel.DataAnnotations.Schema;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("Quarter")]
public class Period : BaseEntity
{
    public string Title { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int? NumberY { get; set; }
    public int? NumberQ { get; set; }
    [Column("IsYear")]
    private int IsYearInt { get; set; }
    [NotMapped]
    public bool IsYear
    {
        get
        {
            return IsYearInt == 1;
        }
    }
}
