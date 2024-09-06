namespace KPICatalog.Domain.Dtos.Entities;

public class RatingScaleDto : BaseDto
{
    public string Name { get; set; }

    public List<RatingScaleValueDto> Values { get; set; }
}
