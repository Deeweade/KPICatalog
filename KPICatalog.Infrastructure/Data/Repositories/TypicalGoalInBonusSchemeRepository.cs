using AutoMapper;
using AutoMapper.QueryableExtensions;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Interfaces.Repositories;
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

    public async Task<IEnumerable<TypicalGoalInBonusSchemeDto?>> GetGoalsInBS()
    {
        return await _context.TypicalGoalInBonusSchemes
            .AsNoTracking()
            .ProjectTo<TypicalGoalInBonusSchemeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}