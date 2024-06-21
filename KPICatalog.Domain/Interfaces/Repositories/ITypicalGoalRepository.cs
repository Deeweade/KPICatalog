using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface ITypicalGoalRepository
{
    Task<TypicalGoalDto?> GetById(int goalId);
    Task<IEnumerable<TypicalGoalDto>> GetAll();
    Task<TypicalGoalDto?> Create(TypicalGoalDto typicalGoalDto);
    Task<TypicalGoalDto> Update(TypicalGoalDto typicalGoalDto);
}