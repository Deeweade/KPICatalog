using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class RatingScaleValuesRepository : IRatingScaleValuesRepository
{
    private readonly PerfManagementDbContext _context;
    private readonly IMapper _mapper;

    public RatingScaleValuesRepository(PerfManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RatingScaleValueDto> Get(int ratingScaleId, decimal fact)
    {
        return await _context.RatingScaleValues
            .AsNoTracking()
            .ProjectTo<RatingScaleValueDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.RatingScaleId == ratingScaleId
                && x.MinimumValue <= fact
                && (x.MaximumValue ?? int.MaxValue) > fact);
    }

}
