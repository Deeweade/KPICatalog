using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Entities;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Domain.Models.Filters;
using AutoMapper;

namespace KPICatalog.Application;

public class BonusSchemeService : IBonusSchemeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BonusSchemeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BonusSchemeDto?> GetById(int schemeId)
    {
        if (schemeId <= 0) throw new ArgumentOutOfRangeException(nameof(schemeId));

        var scheme = await _unitOfWork.BonusSchemeRepository.GetById(schemeId);

        if (scheme is null) return null;

        return _mapper.Map<BonusSchemeDto>(scheme);
    }

    public async Task<IEnumerable<BonusSchemeDto>> GetByFilter(BonusSchemeFilterDto filterDto)
    {
        if (filterDto is null) throw new ArgumentNullException(nameof(filterDto));

        var filter = _mapper.Map<BonusSchemesFilter>(filterDto);

        var schemes = (await _unitOfWork.BonusSchemeRepository.GetByFilter(filter))
            .GroupBy(x => x.CostCenter)
            .Select(x => x.FirstOrDefault())
            .ToList();

        return _mapper.Map<IEnumerable<BonusSchemeDto>>(schemes);
    }
}
