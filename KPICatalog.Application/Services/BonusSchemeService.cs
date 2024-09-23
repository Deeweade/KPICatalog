using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using KPICatalog.Domain.Models.Enums;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class BonusSchemeService : IBonusSchemeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBonusSchemeObjectLinkService _service;

    public BonusSchemeService(IUnitOfWork unitOfWork, IMapper mapper, IBonusSchemeObjectLinkService service)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _service = service;
    }

    public async Task<BonusSchemeView> GetById(int schemeId)
    {
        if (schemeId <= 0) throw new ArgumentOutOfRangeException(nameof(schemeId));

        var scheme = await _unitOfWork.BonusSchemeRepository.GetById(schemeId);

        var result = _mapper.Map<BonusSchemeView>(scheme);

        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(
            new BonusSchemeObjectLinkQueryDto
            {
                BonusSchemeId = schemeId,
                LinkedObjectTypeId = (int)LinkedObjectTypes.Employee
            }, 
            x => x);

        var employeeIds = links.Select(x => x.LinkedObjectId).ToList();

        var employees = await _unitOfWork.EmployeeRepository.GetByIds(employeeIds);

        result.Employees = _mapper.Map<IEnumerable<EmployeeView>>(employees);

        return result;
    }
    
    public async Task<IEnumerable<string>> GetCostCenters()
    {
        return await _unitOfWork.BonusSchemeRepository.GetCostCenters();
    }

    public async Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeQueryView filterView)
    {
        if (filterView is null) throw new ArgumentNullException(nameof(filterView));

        var filterDto = _mapper.Map<BonusSchemeFilterDto>(filterView);

        var schemes = (await _unitOfWork.BonusSchemeRepository.GetByFilter(filterDto))
            .GroupBy(x => x.CostCenter)
            .SelectMany(x => x)
            .ToList();

        var views = _mapper.Map<IEnumerable<BonusSchemeView>>(schemes);

        return views;
    }
    public async Task<IEnumerable<BonusSchemeView>> GetByTypicalGoalId(int goalId)
    {
        if (goalId <= 0) throw new ArgumentOutOfRangeException(nameof(goalId));

        var typicalGoalsDtos = await _unitOfWork.TypicalGoalInBonusSchemeRepository.GetByTypicalGoalId(goalId);

        var typicalGoalsViews = _mapper.Map<List<TypicalGoalInBonusSchemeView>>(typicalGoalsDtos);

        var typicalGoalIds = typicalGoalsViews.Select(x => x.Id).ToList(); 

        var linksFilter = new BonusSchemeObjectLinkQueryDto
        {
            LinkedObjectsIds = typicalGoalIds,
            LinkedObjectTypeId = (int)LinkedObjectTypes.TypicalGoal
        };

        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(linksFilter, x => x);

        var bonusSchemeIds = links.Select(x => x.BonusSchemeId).Distinct().ToList();

        var schemes = await _unitOfWork.BonusSchemeRepository.GetByIds(bonusSchemeIds);

        var schemeViews = _mapper.Map<List<BonusSchemeView>>(schemes);

        foreach (var scheme in schemeViews)
        {
            typicalGoalIds = links.Where(x => x.BonusSchemeId == scheme.Id)
                .Select(x => x.LinkedObjectId)
                .ToList();

            scheme.TypicalGoalInBonusSchemes = typicalGoalsViews.Where(x => typicalGoalIds.Contains(x.Id)).ToList();
        }
        
        return schemeViews;
    }

    public async Task<BonusSchemeView> Create(BonusSchemeView schemeView)
    {
        if (schemeView is null) throw new ArgumentNullException(nameof(schemeView));

        var schemeDto = _mapper.Map<BonusSchemeDto>(schemeView);

        var scheme = await _unitOfWork.BonusSchemeRepository.Create(schemeDto);

        return _mapper.Map<BonusSchemeView>(scheme);
    }

    public async Task<BonusSchemeView> Update(BonusSchemeView schemeView)
    {
        if (schemeView is null) throw new ArgumentNullException(nameof(schemeView));

        var schemeDto = _mapper.Map<BonusSchemeDto>(schemeView);

        var scheme = await _unitOfWork.BonusSchemeRepository.Update(schemeDto);

        return _mapper.Map<BonusSchemeView>(scheme);
    }
    public async Task<BonusSchemeView> Deactivate(int bonusSchemeId, DateTime? dateEnd, int? newBonusSchemeId = null)
    {
        var scheme = await _unitOfWork.BonusSchemeRepository.GetById(bonusSchemeId);

        scheme.DateEnd = dateEnd;
        scheme.IsActive = false;

        await _unitOfWork.BonusSchemeRepository.Update(scheme);

        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(
            new BonusSchemeObjectLinkQueryDto
            {
                BonusSchemeId = bonusSchemeId
            }, 
            x => x);

        foreach (var link in links)
        {
            await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link);
        }

        if (newBonusSchemeId is not null)
        {
            var typeIds = links.Select(x => x.LinkedObjectTypeId).Distinct().ToList();

            foreach (var typeId in typeIds)
            {
                var linkView = new BonusSchemeObjectLinkView
                {
                    BonusSchemeId = (int)newBonusSchemeId,
                    LinkedObjectsIds = links.Where(x => x.LinkedObjectTypeId == typeId && x.BonusSchemeId == bonusSchemeId)
                    .Select(x => (int)x.LinkedObjectId!).Distinct().ToList(),
                    LinkedObjectTypeId = typeId
                };

                await _service.BulkCreate(linkView);
            }
        }

        return _mapper.Map<BonusSchemeView>(scheme);
    }
}
