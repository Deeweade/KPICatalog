
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IEvaluationMethodsRepository
{
    Task<List<EvaluationMethodDto>> GetAll();
}
