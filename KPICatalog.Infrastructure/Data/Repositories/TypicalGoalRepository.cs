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

    public async Task<IEnumerable<TypicalGoalDto>> GetAll()
    {
        return await _context.TypicalGoals
            .AsNoTracking()
            .ProjectTo<TypicalGoalDto>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.PlanningCycleId)
            .ThenBy(x => x.ParentGoalId)
            .ToListAsync();
    }

    public async Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetGoalsInBS()
    {
        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<BonusSchemeDto?>> GetCurrentBS(int goalId, int typicalGoalTypeId)
    {
        var typicalGoal = await _context.TypicalGoals.FindAsync(goalId);

        var typicalGoals = await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.TypicalGoalId == goalId)
            .ToListAsync();

        // Получаем все Id этих TypicalGoalInBonusScheme
        var typicalGoalIds = typicalGoals.Select(x => x.Id).ToList();

        // Получаем все BonusSchemeObjectLink, у которых LinkedObjectId входит в список typicalGoalIds и LinkedObjectTypeId равен типу связи БС-Типовая цель
        var bonusSchemeLinks = await _context.BonusSchemeObjectLinks
            .AsNoTracking()
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider)
            .Where(x => typicalGoalIds.Contains((int)x.LinkedObjectId!) && x.LinkedObjectTypeId == typicalGoalTypeId)
            .ToListAsync();

        // Получаем все Id этих BonusScheme
        var bonusSchemeIds = bonusSchemeLinks.Select(x => x.BonusSchemeId).Distinct().ToList();

        // Получаем все BonusScheme, у которых Id входит в список bonusSchemeIds
        var bonusSchemes = await _context.BonusSchemes
            .AsNoTracking()
            .ProjectTo<BonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => bonusSchemeIds.Contains(x.Id))
            .ToListAsync();

        return bonusSchemes;
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
        goal.PlanningCycleId = typicalGoalDto.PlanningCycleId;
        goal.WeightTypeId = typicalGoalDto.WeightTypeId;
        goal.ParentGoalId = typicalGoalDto.ParentGoalId;
        goal.ExternalId = typicalGoalDto.ExternalId;

        await _context.SaveChangesAsync();

        return await GetById(goal.Id);
    }

}