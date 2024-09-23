using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class BonusSchemeController : ControllerBase
{
    private readonly IBonusSchemeService _service;

    public BonusSchemeController(IBonusSchemeService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var scheme = await _service.GetById(id);

        return Ok(scheme);
    }

    [HttpGet("costCenters")]
    public async Task<IActionResult> GetCostCenters()
    {
        var centers = await _service.GetCostCenters();

        return Ok(centers);
    }

    [HttpPost("getFiltered")]
    public async Task<IActionResult> GetFiltered(BonusSchemeQueryView filter)
    {
        if (filter is null) filter = new BonusSchemeQueryView();

        var schemes = await _service.GetByFilter(filter);

        return Ok(schemes);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post(BonusSchemeView schemeView)
    {
        if (schemeView is null) throw new ArgumentNullException(nameof(schemeView));

        var scheme = await _service.Create(schemeView);

        return CreatedAtAction(nameof(Get), new { id = scheme.Id}, scheme);
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BonusSchemeView schemeView)
    {
        if (schemeView is null) throw new ArgumentNullException(nameof(schemeView));

        if (id != schemeView.Id) return BadRequest();

        var scheme = await _service.Update(schemeView);

        return Ok(scheme);
    }

    [HttpPost("delete/{bonusSchemeId}")]
    public async Task<IActionResult> Delete(int bonusSchemeId, [FromBody] BonusSchemeView schemeView, [FromQuery] int? newBonusSchemeId)
    {
        if (schemeView is null) throw new ArgumentNullException(nameof(schemeView));

        if (bonusSchemeId != schemeView.Id) return BadRequest();

        var scheme = await _service.Deactivate(bonusSchemeId, schemeView.DateEnd, newBonusSchemeId);

        return Ok(scheme);
    }
}
