using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;
using KPICatalog.Domain.Dtos.Entities;
using System.Globalization;

namespace KPICatalog.Application.Services;

public class TypicalGoalInBonusSchemeService : ITypicalGoalInBonusSchemeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypicalGoalInBonusSchemeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypicalGoalInBonusSchemeView?>> GetByTypicalGoalId(int id)
    {
        var goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByTypicalGoalId(id);

        if(goals is null) return null;

        return _mapper.Map<IEnumerable<TypicalGoalInBonusSchemeView>>(goals);
    }


    public async Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals)
    {
        if (bonusSchemesIds is null) throw new ArgumentNullException(nameof(bonusSchemesIds));
        if (typicalGoals is null) throw new ArgumentNullException(nameof(typicalGoals));

        foreach (var typicalGoal in typicalGoals)
        {
            var goalsInSchemeDtos = new List<TypicalGoalInBonusSchemeDto>();

            foreach(var periodId in typicalGoal.TypicalGoalInBonusSchemeView.PeriodIds)
            {
                typicalGoal.TypicalGoalInBonusSchemeView.PeriodId = periodId;

                var goalInScheme = new TypicalGoalInBonusSchemeDto
                {
                    TypicalGoalId = typicalGoal.Id,
                    ParentBSTypicalGoalId = typicalGoal.TypicalGoalInBonusSchemeView.ParentBSTypicalGoalId,
                    PeriodId = typicalGoal.TypicalGoalInBonusSchemeView.PeriodId,
                    Weight = typicalGoal.TypicalGoalInBonusSchemeView.Weight,
                    Plan = typicalGoal.TypicalGoalInBonusSchemeView.Plan,
                    TypeKeyResultID = typicalGoal.TypicalGoalInBonusSchemeView.TypeKeyResultID,
                    EvaluationProvider = typicalGoal.TypicalGoalInBonusSchemeView.EvaluationProvider,
                    BonusSchemeLinkMethodId = typicalGoal.TypicalGoalInBonusSchemeView.BonusSchemeLinkMethodId,
                    EvaluationMethodId = typicalGoal.TypicalGoalInBonusSchemeView.EvaluationMethodId,
                    RatingScaleId = typicalGoal.TypicalGoalInBonusSchemeView.RatingScaleId,
                    Fact = typicalGoal.TypicalGoalInBonusSchemeView.Fact,
                    Evaluation = typicalGoal.TypicalGoalInBonusSchemeView.Evaluation
                };

                goalsInSchemeDtos.Add(goalInScheme);

                //await _unitOfWork.TypicalGoalInBonusSchemeRepository.Create(goalInScheme);
                
                foreach (var child in typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id).ToList())
                {
                    var childGoalsInSchemeDtos = Create(child);

                    goalsInSchemeDtos.AddRange(childGoalsInSchemeDtos);
                }
            }

        }
    }

    private List<TypicalGoalInBonusSchemeDto> Create(TypicalGoalView typicalGoal)
    {
        if (typicalGoal is null) throw new ArgumentNullException(nameof(typicalGoal));
        if (typicalGoal.TypicalGoalInBonusSchemeView is null) throw new ArgumentNullException(nameof(typicalGoal.TypicalGoalInBonusSchemeView));

        var goalsInSchemeDtos = new List<TypicalGoalInBonusSchemeDto>();

        foreach(var periodId in typicalGoal.TypicalGoalInBonusSchemeView.PeriodIds)
        {
            typicalGoal.TypicalGoalInBonusSchemeView.PeriodId = periodId;

            var goalInScheme = new TypicalGoalInBonusSchemeDto
            {
                TypicalGoalId = typicalGoal.Id,
                ParentBSTypicalGoalId = typicalGoal.TypicalGoalInBonusSchemeView.ParentBSTypicalGoalId,
                PeriodId = typicalGoal.TypicalGoalInBonusSchemeView.PeriodId,
                Weight = typicalGoal.TypicalGoalInBonusSchemeView.Weight,
                Plan = typicalGoal.TypicalGoalInBonusSchemeView.Plan,
                TypeKeyResultID = typicalGoal.TypicalGoalInBonusSchemeView.TypeKeyResultID,
                EvaluationProvider = typicalGoal.TypicalGoalInBonusSchemeView.EvaluationProvider,
                BonusSchemeLinkMethodId = typicalGoal.TypicalGoalInBonusSchemeView.BonusSchemeLinkMethodId,
                EvaluationMethodId = typicalGoal.TypicalGoalInBonusSchemeView.EvaluationMethodId,
                RatingScaleId = typicalGoal.TypicalGoalInBonusSchemeView.RatingScaleId,
                Fact = typicalGoal.TypicalGoalInBonusSchemeView.Fact,
                Evaluation = typicalGoal.TypicalGoalInBonusSchemeView.Evaluation
            };

            goalsInSchemeDtos.Add(goalInScheme);

            // foreach (var child in typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id).ToList())
            // {
            //     var childGoalsInSchemeDtos = Create(child);

            //     goalsInSchemeDtos.AddRange(childGoalsInSchemeDtos);
            // }
        }

        return goalsInSchemeDtos;
    }
}
