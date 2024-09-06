
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IRatingScalesRepository
{
    Task<List<RatingScaleDto>> GetAll();
}
