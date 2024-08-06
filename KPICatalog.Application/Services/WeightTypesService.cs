using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class WeightTypesService : IWeightTypesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WeightTypesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<WeightTypeView>> GetAll()
    {
        var types = await _unitOfWork.WeightTypesRepository.GetAll();

        return _mapper.Map<List<WeightTypeView>>(types);
    }
}
