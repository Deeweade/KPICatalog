using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class BonusSchemeController : ControllerBase
{
    private readonly IBonusSchemeService _service;
    private readonly IMapper _mapper;

    public BonusSchemeController(IBonusSchemeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        if (!int.TryParse(id, out var schemeId)) throw new ArgumentNullException(nameof(id));

        var scheme = await _service.GetById(schemeId);

        return Ok(scheme);
    }

    [HttpPost("getFiltered")]
    public async Task<IActionResult> GetFiltered(BonusSchemeFilterView filter)
    {
        if (filter is null) filter = new BonusSchemeFilterView();

        var filterDto = _mapper.Map<BonusSchemeFilterDto>(filter);

        var schemes = await _service.GetByFilter(filterDto);

        return Ok(schemes);
    }
}
