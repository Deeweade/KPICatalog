using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class BonusSchemeService : IBonusSchemeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BonusSchemeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BonusSchemeView?> GetById(int schemeId)
    {
        if (schemeId <= 0) throw new ArgumentOutOfRangeException(nameof(schemeId));

        var scheme = await _unitOfWork.BonusSchemeRepository.GetById(schemeId);

        if (scheme is null) return null;

        return _mapper.Map<BonusSchemeView>(scheme);
    }
    
    public async Task<IEnumerable<string>> GetCostCenters()
    {
        return await _unitOfWork.BonusSchemeRepository.GetCostCenters();
    }

    public async Task<IEnumerable<BonusSchemeView>> GetByFilter(BonusSchemeFilterView filterView)
    {
        if (filterView is null) throw new ArgumentNullException(nameof(filterView));

        var filterDto = _mapper.Map<BonusSchemeFilterDto>(filterView);

        var schemes = (await _unitOfWork.BonusSchemeRepository.GetByFilter(filterDto))
            .GroupBy(x => x.CostCenter)
            .Select(x => x.FirstOrDefault())
            .ToList();

        var result = _mapper.Map<IEnumerable<BonusSchemeView>>(schemes);

        return result;
    }

    public async Task<BonusSchemeView?> Create(BonusSchemeView schemeView)
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
}
