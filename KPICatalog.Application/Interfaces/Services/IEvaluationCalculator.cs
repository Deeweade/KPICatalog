using KPICatalog.Domain.Models.Enums;

namespace KPICatalog.Application.Interfaces.Services;

public interface IEvaluationCalculator
{
    Task<decimal> Calculate(decimal plan, decimal fact, EvaluationMethods evaluationMethodId, int? ratingScaleId = null);
}
