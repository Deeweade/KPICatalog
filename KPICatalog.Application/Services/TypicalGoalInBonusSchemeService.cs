using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Models.Enums;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

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

        //подготавливаем список ТЦ в БС
        var goalsInScheme = new List<TypicalGoalInBonusSchemeDto>();

        foreach (var typicalGoal in typicalGoals)
        {
            foreach(var periodId in typicalGoal.TypicalGoalInBonusScheme.PeriodIds)
            {
                var goalInScheme = _mapper.Map<TypicalGoalInBonusSchemeDto>(typicalGoal.TypicalGoalInBonusScheme);
                
                goalInScheme.TypicalGoalId = typicalGoal.Id;
                
                goalInScheme.PeriodId = periodId;

                goalsInScheme.Add(goalInScheme);
            }
        }

        //сохраняем все ТЦ в БС в бд
        var ids = await _unitOfWork.TypicalGoalInBonusSchemeRepository.BulkCreate(goalsInScheme);

        //привязываем дочерние цели к родительским
        var goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByIds(ids);

        var yearIds = (await _unitOfWork.PeriodsRepository.GetAll()).Where(x => x.IsYear).Select(x => x.Id).ToList();

        var parentTypicalGoalIds = goals.Where(x => yearIds.Any(id => id == x.PeriodId)).Select(x => x.TypicalGoalId).ToList();

        var childrenTypicalGoalIds = await _unitOfWork.TypicalGoalRepository.Query()
            .Where(x => parentTypicalGoalIds.Any(id => id == x.ParentGoalId))
            .Select(x => x.Id)
            .ToListAsync();

        var children = goals.Where(x => childrenTypicalGoalIds.Any(id => id == x.TypicalGoalId)).ToList();

        var childrenParentsPairs = await _unitOfWork.TypicalGoalRepository.Query()
            .ToDictionaryAsync(x => x.Id, x => x.ParentGoalId);

        foreach (var child in children)
        {
            child.ParentBSTypicalGoalId = childrenParentsPairs.Where(x => x.Key == child.ParentBSTypicalGoalId)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        await _unitOfWork.TypicalGoalInBonusSchemeRepository.BulkUpdate(children);

        return ids.ToList();
    }

    // private async Task<List<int>> Create(IEnumerable<TypicalGoalView> typicalGoals)
    // {
    //     if (typicalGoals is null) throw new ArgumentNullException(nameof(typicalGoals));

    //     var periods = await _unitOfWork.PeriodsRepository.GetAll();

    //     var goalsInSchemeIds = new List<int>();

    //     foreach (var typicalGoal in typicalGoals)
    //     {
    //         var goalInScheme = _mapper.Map<TypicalGoalInBonusSchemeDto>(typicalGoal.TypicalGoalInBonusScheme);

    //         goalInScheme.TypicalGoalId = typicalGoal.Id;

    //         var parentPeriod = periods.FirstOrDefault(x => x.Id == periodId);

    //         var childPeriods = periods.Where(x => x.NumberY == parentPeriod.NumberY).Select(x => x.Id);

    //         var children = typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id
    //             && x.TypicalGoalInBonusScheme.PeriodIds.Any(id => childPeriods.Any(child => child == id)));

    //         foreach(var periodId in typicalGoal.TypicalGoalInBonusScheme.PeriodIds)
    //         {
    //             goalInScheme.PeriodId = periodId;

    //             var createdGoal = await _unitOfWork.TypicalGoalInBonusSchemeRepository.Create(goalInScheme);

    //             goalsInSchemeIds.Add(createdGoal.Id);

    //             foreach (var goal in typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id))
    //             {
    //                 goal.TypicalGoalInBonusScheme.ParentBSTypicalGoalId = createdGoal.Id;
    //             }

    //             var children = await Create(typicalGoals.Where(x => x.ParentGoalId == typicalGoal.Id));

    //             goalsInSchemeIds.AddRange(children);
    //         }
    //     }

    //     return goalsInSchemeIds;
    // }
}
