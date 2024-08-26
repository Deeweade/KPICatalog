using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Enums;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using KPICatalog.Domain.Models.Enums;

namespace KPICatalog.Application.Services;

public class GoalsService : IGoalsService
{
    private readonly IGoalsRepository _goalsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GoalsService(IGoalsRepository goalsRepository, IUnitOfWork unitOfWork)
    {
        _goalsRepository = goalsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task SyncGoals(SyncMethods syncMethod, List<int> employeeIds = null, 
        List<int> goalIds = null, List<int> bonusSchemeIds = null)
    {
        var goalDtos = new List<TypicalGoalInBonusSchemeDto>();
        var bonusSchemeDtos = new List<BonusSchemeDto>();

        if (bonusSchemeIds is not null && bonusSchemeIds.Any())
        {
            var filter = new BonusSchemeObjectLinkFilterDto
            {
                BonusSchemeIds = bonusSchemeIds.Distinct().ToList(),
                LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal
            };

            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

            var goalsIds = links.Select(x => x.LinkedObjectId).Distinct().ToList();
        }

        if (goalIds is not null && goalIds.Any())
        {
            var filter = new BonusSchemeObjectLinkFilterDto
            {
                LinkedObjectsIds = goalIds.Distinct().ToList(),
                LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal
            };

            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

            bonusSchemeIds = links.Select(x => x.BonusSchemeId).Distinct().ToList();
        }

        if (employeeIds is null || !employeeIds.Any())
        {
            var filter = new BonusSchemeObjectLinkFilterDto
            {
                BonusSchemeIds = bonusSchemeIds.Distinct().ToList(),
                LinkedObjectTypeId = (int)LinkedObjectTypes.Employee
            };

            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

            employeeIds = links.Select(x => x.LinkedObjectId).Distinct().ToList();
        }

        var data = new GoalsForEmployeesRequestDto
        {
            Goals = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByIds(goalIds),
            EmployeesIds = employeeIds
        };

        switch (syncMethod)
        {
            case SyncMethods.Update:
                await _goalsRepository.BulkUpdate(data);
                break;
            case SyncMethods.Delete:
                await _goalsRepository.BulkDelete(data);
                break;
        }
    }
}
