using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;
using KPICatalog.Domain.Dtos.Entities;
using System.Globalization;
using KPICatalog.Domain.Models.Entities.KPICatalog;
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

        var goalsIds = await Create(typicalGoals.Where(x => x.TypicalGoalInBonusScheme.BonusSchemeLinkMethodId == (int)BonusSchemeObjectLinkMethods.ForAll));

        foreach (var bonusSchemesId in bonusSchemesIds)
        {
            var ids = await Create(typicalGoals.Where(x => x.TypicalGoalInBonusScheme.BonusSchemeLinkMethodId != (int)BonusSchemeObjectLinkMethods.ForAll));

            ids.AddRange(goalsIds);

            var dto = new BonusSchemeObjectLinkDto
            {
                LinkedObjectsIds = ids,
                LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal,
                BonusSchemeId = bonusSchemesId
            };
            
            await _unitOfWork.BonusSchemeObjectLinkRepository.BulkCreate(dto);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<List<int>> Create(IEnumerable<TypicalGoalView> typicalGoals)
    {
        if (typicalGoals is null) throw new ArgumentNullException(nameof(typicalGoals));

        var goalsInSchemeIds = new List<int>();

        foreach (var typicalGoal in typicalGoals)
        {
            var goalInScheme = _mapper.Map<TypicalGoalInBonusSchemeDto>(typicalGoal.TypicalGoalInBonusScheme);

            goalInScheme.TypicalGoalId = typicalGoal.Id;

            foreach(var periodId in typicalGoal.TypicalGoalInBonusScheme.PeriodIds)
            {
                goalInScheme.PeriodId = periodId;

                goalInScheme = await _unitOfWork.TypicalGoalInBonusSchemeRepository.Create(goalInScheme);

                goalsInSchemeIds.Add(goalInScheme.Id);

                foreach (var goal in typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id))
                {
                    goal.TypicalGoalInBonusScheme.ParentBSTypicalGoalId = goalInScheme.Id;
                }

                var children = await Create(typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id));

                goalsInSchemeIds.AddRange(children);
            }
        }

        return goalsInSchemeIds;
    }
}
