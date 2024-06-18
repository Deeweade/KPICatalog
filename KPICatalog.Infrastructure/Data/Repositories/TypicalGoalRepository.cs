using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using KPICatalog.Domain.Models.Entities.KPICatalog;

namespace KPICatalog.Infrastructure;

public class TypicalGoalRepository : ITypicalGoalRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public TypicalGoalRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TypicalGoalDto?> GetById(int goalId)
    {
        if (goalId <= 0 ) throw new ArgumentOutOfRangeException(nameof(goalId));

        return await _context.TypicalGoals
            .AsNoTracking()
            .ProjectTo<TypicalGoalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == goalId);
    }

    public async Task<TypicalGoalDto?> Create(TypicalGoalDto typicalGoalDto)
    {
        if (typicalGoalDto is null) throw new ArgumentNullException(nameof(typicalGoalDto));

        var goal = _mapper.Map<TypicalGoal>(typicalGoalDto);

        _context.Add(goal);

        await _context.SaveChangesAsync();

        return await GetById(goal.Id);
    }

    public async Task<TypicalGoalDto> Update(TypicalGoalDto typicalGoalDto)
    {
        if (typicalGoalDto is null) throw new ArgumentNullException(nameof(typicalGoalDto));

        var goal = await _context.TypicalGoals.FirstOrDefaultAsync(x => x.Id == typicalGoalDto.Id);

        goal.Title = typicalGoalDto.Title;
        goal.GoalTypeId = typicalGoalDto.GoalTypeId;
        goal.WeightTypeId = typicalGoalDto.WeightTypeId;
        goal.ParentGoalId = typicalGoalDto.ParentGoalId;
        goal.ExternalId = typicalGoalDto.ExternalId;

        await _context.SaveChangesAsync();

        return await GetById(goal.Id);
    }

}