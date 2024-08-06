
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IWeightTypesRepository
{
    Task<List<WeightTypeDto>> GetAll();
}
