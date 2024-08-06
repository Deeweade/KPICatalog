using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class PlanningCyclesService : IPlanningCyclesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlanningCyclesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PlanningCycleView>> GetAll()
    {
        var cycles = await _unitOfWork.PlanningCyclesRepository.GetAll();

        return _mapper.Map<List<PlanningCycleView>>(cycles);
    }
}
