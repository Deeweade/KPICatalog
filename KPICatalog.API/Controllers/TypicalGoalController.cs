using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class TypicalGoalController : ControllerBase
{
    private readonly ITypicalGoalService _service;

    public TypicalGoalController(ITypicalGoalService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var goal = await _service.GetById(id);

        return Ok(goal);
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> GetAll()
    {
        var goal = await _service.GetAll();

        return Ok(goal);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post(TypicalGoalView goalView)
    {
        if (goalView is null) throw new ArgumentNullException(nameof(goalView));

        var goal = await _service.Create(goalView);

        return CreatedAtAction(nameof(Get), new { id = goal.Id}, goal);
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TypicalGoalView goalView)
    {
        if (goalView is null) throw new ArgumentNullException(nameof(goalView));

        if (id != goalView.Id) return BadRequest();

        var goal = await _service.Update(goalView);

        return Ok(goal);
    }
}