
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IRatingScaleValuesRepository
{
    Task<RatingScaleValueDto> Get(int ratingScaleId, decimal fact);
}
