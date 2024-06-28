using AutoMapper;
using AutoMapper.QueryableExtensions;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<TypicalGoalInBonusSchemeDto?>> GetByTypicalGoalId(int goalId)
    {
        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.TypicalGoalId == goalId)
            .ToListAsync();
    }
}