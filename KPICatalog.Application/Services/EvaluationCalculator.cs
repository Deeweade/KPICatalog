using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Domain.Models.Enums;

namespace KPICatalog.Application.Services;

public class EvaluationCalculator : IEvaluationCalculator
{
    private readonly IRatingScaleValuesRepository _repository;

    public EvaluationCalculator(IRatingScaleValuesRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<decimal> Calculate(decimal plan, decimal fact, EvaluationMethods evaluationMethod, int? ratingScaleId = null)
    {
        decimal result;

        switch (evaluationMethod)
        {
            case EvaluationMethods.Direct:
                result = fact / plan * 100;
                break;
            case EvaluationMethods.Inverse:
                var evaluation = (1 + (plan - fact) / plan) * 100;

                result = evaluation >= 0 ? evaluation : 0;
                break;
            case EvaluationMethods.RatingScale:
                var dto = await _repository.Get((int)ratingScaleId, fact);

                result = (decimal)dto.RatingPercentage;
                break;
            default:
                result = 0;
                break;
        }

        return Math.Round(result, 2, MidpointRounding.AwayFromZero);
    }
}
