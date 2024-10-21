using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Linq.Expressions;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class TypicalGoalInBonusSchemeRepository : ITypicalGoalInBonusSchemeRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public TypicalGoalInBonusSchemeRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TResult>> GetByQuery<TResult>(TypicalGoalInBSQueryDto queryDto, 
        Expression<Func<TypicalGoalInBonusSchemeDto, TResult>> select = null)
    {
        if (queryDto is null) throw new ArgumentNullException(nameof(queryDto));

        var query = _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider);

        if (queryDto.TypicalGoalId is not null)
        {
            query = query.Where(x => x.TypicalGoalId == queryDto.TypicalGoalId);
        }

        if (queryDto.Ids is not null && queryDto.Ids.Any())
        {
            query = query.Where(x => queryDto.Ids.Contains(x.Id));
        }
        if (queryDto.PeriodIds is not null && queryDto.PeriodIds.Any())
        {
            query = query.Where(x => queryDto.PeriodIds.Contains(x.PeriodId));
        }

        if (select is not null)
        {
            return await query.Select(select).ToListAsync();
        }
        else
        {
            return await query.Cast<TResult>().ToListAsync();
        }
    }

    public async Task<List<TypicalGoalInBonusSchemeDto>> GetByIds(List<int> goalsIds)
    {
        if (goalsIds is null) throw new ArgumentNullException(nameof(goalsIds));

        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => goalsIds.Any(id => id == x.Id))
            .ToListAsync();
    }

    public async Task<List<TypicalGoalInBonusSchemeDto>> GetByTypicalGoalId(int goalId)
    {
        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .Include(x => x.RatingScale.Values)
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

    public async Task BulkUpdate(List<TypicalGoalInBonusSchemeDto> goalsDtos)
    {
        if (goalsDtos is null) throw new ArgumentNullException(nameof(goalsDtos));

        var ids = goalsDtos.Select(x => x.Id).ToList();

        var goals = await _context.TypicalGoalInBonusSchemes
            .Where(x => ids.Any(id => id == x.Id))
            .ToListAsync();

        foreach (var goal in goals)
        {
            var goalDto = goalsDtos.FirstOrDefault(x => x.Id == goal.Id);

            goal.Weight = goalDto.Weight;
            goal.Plan = goalDto.Plan;
            goal.PeriodId = goalDto.PeriodId;
            goal.TypeKeyResultId = goalDto.TypeKeyResultId;
            goal.EvaluationProvider = goalDto.EvaluationProvider;
            goal.EvaluationMethodId = goalDto.EvaluationMethodId;
            goal.RatingScaleId = goalDto.RatingScaleId;
            goal.BonusSchemeLinkMethodId = goalDto.BonusSchemeLinkMethodId;
            goal.Fact = goalDto.Fact ?? goal.Fact;
            goal.Evaluation = goalDto.Evaluation ?? goal.Evaluation;
        }

        await _context.SaveChangesAsync();
    }
}