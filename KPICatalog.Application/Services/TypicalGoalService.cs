using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class TypicalGoalService : ITypicalGoalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypicalGoalService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TypicalGoalView?> GetById(int goalId)
    {
        if (goalId <= 0) throw new ArgumentOutOfRangeException(nameof(goalId));

        var goal = await _unitOfWork.TypicalGoalRepository.GetById(goalId);

        if (goal is null) return null;

        var result = _mapper.Map<TypicalGoalView>(goal);

        return result;
    }

    public async Task<IEnumerable<TypicalGoalView>> GetAll()
    {
        var goal = await _unitOfWork.TypicalGoalRepository.GetAll();

        if (goal is null) return null;

        var result = _mapper.Map<IEnumerable<TypicalGoalView>>(goal);

        return result;
    }

    public async Task<TypicalGoalView?> Create(TypicalGoalView typicalGoalView)
    {
        if (typicalGoalView is null) throw new ArgumentNullException(nameof(typicalGoalView));

        var typicalGoalDto = _mapper.Map<TypicalGoalDto>(typicalGoalView);

        var goal = await _unitOfWork.TypicalGoalRepository.Create(typicalGoalDto);

        return _mapper.Map<TypicalGoalView>(goal);
    }

    public async Task<TypicalGoalView?> Update(TypicalGoalView typicalGoalView)
    {
        if (typicalGoalView is null) throw new ArgumentNullException(nameof(typicalGoalView));

        var typicalGoalDto = _mapper.Map<TypicalGoalDto>(typicalGoalView);

        var goal = await _unitOfWork.TypicalGoalRepository.Update(typicalGoalDto);

        return _mapper.Map<TypicalGoalView>(goal);
    }
}