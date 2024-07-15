using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Models.Enums;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Application.Services;

public class TypicalGoalInBonusSchemeService : ITypicalGoalInBonusSchemeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEvaluationCalculator _evaluationCalculator;

    public TypicalGoalInBonusSchemeService(IUnitOfWork unitOfWork, IMapper mapper, 
        IEvaluationCalculator evaluationCalculator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _evaluationCalculator = evaluationCalculator;
    }

    public async Task<IEnumerable<TypicalGoalInBonusSchemeView>> GetByTypicalGoalId(int id)
    {
        var goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByTypicalGoalId(id);

        if(goals is null) return null;

        return _mapper.Map<IEnumerable<TypicalGoalInBonusSchemeView>>(goals);
    }

    public async Task<GoalsForEmployeesRequestView> GetGoalsToSync(int bonusSchemeId)
    {
        if (bonusSchemeId <= 0) throw new ArgumentOutOfRangeException(nameof(bonusSchemeId));

        var filter = new BonusSchemeObjectLinkFilterDto
        {
            BonusSchemeId = bonusSchemeId,
            LinkedObjectTypeId = (int)LinkedObjectTypes.Employee
        };

        var employeesIds = (await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter))
            .Select(x => x.LinkedObjectId)
            .ToList();

        filter.LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal;

        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

        var goalsIds = links.Select(x => x.LinkedObjectId).ToList();

        var goalsDtos = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByIds(goalsIds);

        var goalsViews = _mapper.Map<List<TypicalGoalInBonusSchemeView>>(goalsDtos);

        var typicalGoalIds = goalsDtos.Select(x => x.TypicalGoalId).Distinct().ToList();

        var typicalGoals = await _unitOfWork.TypicalGoalRepository.GetByIds(typicalGoalIds);

        foreach (var view in goalsViews)
        {
            var typicalGoal = typicalGoals.FirstOrDefault(x => x.Id == view.TypicalGoalId);

            view.Title = typicalGoal.Title;
            view.PlanningCycleId = typicalGoal.PlanningCycleId;
        }

        return new GoalsForEmployeesRequestView
        {
            Goals = goalsViews,
            EmployeesIds = employeesIds
        };
    }

    public async Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals)
    {
        if (bonusSchemesIds is null) throw new ArgumentNullException(nameof(bonusSchemesIds));
        if (typicalGoals is null) throw new ArgumentNullException(nameof(typicalGoals));

        var goalsIds = await Create(typicalGoals.Where(x => x.TypicalGoalInBonusScheme.BonusSchemeLinkMethodId == (int)BonusSchemeObjectLinkMethods.ForAll).ToList());

        foreach (var bonusSchemesId in bonusSchemesIds)
        {
            var ids = await Create(typicalGoals.Where(x => x.TypicalGoalInBonusScheme.BonusSchemeLinkMethodId != (int)BonusSchemeObjectLinkMethods.ForAll).ToList());

            ids.AddRange(goalsIds);

            var dto = new BonusSchemeObjectLinkDto
            {
                LinkedObjectsIds = ids,
                LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal,
                BonusSchemeId = bonusSchemesId
            };
            
            await _unitOfWork.BonusSchemeObjectLinkRepository.BulkCreate(dto);
        }
    }

    public async Task BulkUpdate(ICollection<int> entitiesIds, TypicalGoalInBonusSchemeView typicalGoalInBS)
    {
        if (entitiesIds is null) throw new ArgumentNullException(nameof(entitiesIds));
        if (typicalGoalInBS is null) throw new ArgumentNullException(nameof(typicalGoalInBS));

        var goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByIds(entitiesIds.ToList());

        var periodIds = goals.Select(x => x.PeriodId).Distinct().ToList();

        if (periodIds.Count() > 1) throw new Exception("Forbidden to change the period for goals which periods aren't the same!");

        foreach(var goal in goals)
        {
            if (goal.Fact.HasValue && goal.Evaluation.HasValue) return;

            goal.Weight = typicalGoalInBS.Weight;
            goal.Plan = typicalGoalInBS.Plan;
            goal.TypeKeyResultId = typicalGoalInBS.TypeKeyResultId;
            goal.EvaluationProvider = typicalGoalInBS.EvaluationProvider;
            goal.EvaluationMethodId = typicalGoalInBS.EvaluationMethodId;
            goal.RatingScaleId = typicalGoalInBS.RatingScaleId;

            if (goal.BonusSchemeLinkMethodId != (int)BonusSchemeObjectLinkMethods.ForAll 
                && typicalGoalInBS.BonusSchemeLinkMethodId != (int)BonusSchemeObjectLinkMethods.ForAll)
            {
                goal.BonusSchemeLinkMethodId = typicalGoalInBS.BonusSchemeLinkMethodId;
            }
        }

        await _unitOfWork.TypicalGoalInBonusSchemeRepository.BulkUpdate(goals.ToList());
    }

    private async Task<List<int>> Create(List<TypicalGoalView> typicalGoals)
    {
        if (typicalGoals is null) throw new ArgumentNullException(nameof(typicalGoals));

        var periods = await _unitOfWork.PeriodsRepository.GetAll();

        var goalsInSchemeIds = new List<int>();

        foreach (var typicalGoal in typicalGoals.Where(x => x.PlanningCycleId == (int)PlanningCycles.Year))
        {
            var goalInScheme = _mapper.Map<TypicalGoalInBonusSchemeDto>(typicalGoal.TypicalGoalInBonusScheme);

            goalInScheme.TypicalGoalId = typicalGoal.Id;

            foreach(var periodId in typicalGoal.TypicalGoalInBonusScheme.PeriodIds)
            {
                goalInScheme.PeriodId = periodId;

                var createdGoal = await _unitOfWork.TypicalGoalInBonusSchemeRepository.Create(goalInScheme);

                goalsInSchemeIds.Add(createdGoal.Id);

                var period = periods.FirstOrDefault(x => x.Id == goalInScheme.PeriodId);

                var childrenPeriodsIds = periods.Where(x => x.NumberY == period.NumberY
                    && x.IsYear == 0)
                    .Select(x => x.Id)
                    .ToList();

                var children = new List<TypicalGoalInBonusSchemeDto>();

                foreach (var goal in typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id).ToList())
                {
                    foreach (var goalPeriodId in goal.TypicalGoalInBonusScheme.PeriodIds.Where(x => childrenPeriodsIds.Any(id => id == x)).ToList())
                    {
                        var child = _mapper.Map<TypicalGoalInBonusSchemeDto>(goal.TypicalGoalInBonusScheme);

                        child.TypicalGoalId = goal.Id;
                        child.ParentBSTypicalGoalId = createdGoal.Id;
                        child.PeriodId = goalPeriodId;

                        children.Add(child);
                    }
                }

                var childrenIds = await _unitOfWork.TypicalGoalInBonusSchemeRepository.BulkCreate(children);

                goalsInSchemeIds.AddRange(childrenIds);
            }
        }

        return goalsInSchemeIds;
    }

    public async Task BulkEvaluate(List<BulkEvaluateGoalsView> views)
    {
        ArgumentNullException.ThrowIfNull(nameof(views));

        foreach (var view in views)
        {
            var goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByIds(view.TypicalGoalsInBSIds.ToList());

            foreach (var goal in goals)
            {
                goal.Fact = view.Fact;
                goal.Evaluation = await _evaluationCalculator.Calculate(goal.Plan, view.Fact, (EvaluationMethods)goal.EvaluationMethodId, goal.RatingScaleId);
            }

            await _unitOfWork.TypicalGoalInBonusSchemeRepository.BulkUpdate(goals);
        }
    }
}
