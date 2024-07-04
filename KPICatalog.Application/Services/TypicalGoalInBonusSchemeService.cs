﻿using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Models.Enums;

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
}