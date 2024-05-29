using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KPICatalog.Application.Models.Entities;

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

    [HttpPost("getFiltered")]
    public async Task<IActionResult> GetFiltered(BonusSchemeFilterView filter)
    {
        if (filter is null) filter = new BonusSchemeFilterView();

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
}
