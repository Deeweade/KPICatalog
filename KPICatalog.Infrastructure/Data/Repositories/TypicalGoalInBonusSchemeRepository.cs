using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure;

public class TypicalGoalInBonusSchemeRepository : ITypicalGoalInBonusSchemeRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public TypicalGoalInBonusSchemeRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByIds(List<int> goalsIds)
    {
        if (goalsIds is null) throw new ArgumentNullException(nameof(goalsIds));

        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => goalsIds.Contains(x.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByTypicalGoalId(int goalId)
    {
        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.TypicalGoalId == goalId)
            .ToListAsync();
    }

    public async Task<TypicalGoalInBonusSchemeDto> Create(TypicalGoalInBonusSchemeDto goalDto)
    {
        if (goalDto is null) throw new ArgumentNullException(nameof(goalDto));

        var goal = _mapper.Map<TypicalGoalInBonusScheme>(goalDto);

        _context.Add(goal);

        await _context.SaveChangesAsync();

        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == goal.Id);
    }

    public async Task<IEnumerable<int>> BulkCreate(List<TypicalGoalInBonusSchemeDto> goalsDto)
    {
        var goals = _mapper.Map<List<TypicalGoalInBonusScheme>>(goalsDto);

        _context.AddRange(goals);

        await _context.SaveChangesAsync();

        return goals
            .Select(x => x.Id)
            .ToList();
    }
}