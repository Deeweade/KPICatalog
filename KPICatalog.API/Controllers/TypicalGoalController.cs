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
    private readonly ITypicalGoalService _serviceTG;
    private readonly ITypicalGoalInBonusSchemeService _serviceTGBS;
    private readonly IBonusSchemeService _serviceBS;

    public TypicalGoalController(ITypicalGoalService serviceTG, ITypicalGoalInBonusSchemeService serviceTGBS, IBonusSchemeService serviceBS)
    {
        _serviceTG = serviceTG;
        _serviceTGBS = serviceTGBS;
        _serviceBS = serviceBS;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var goal = await _serviceTG.GetById(id);
        var currentBS = await _serviceBS.GetByTypicalGoalId(id);
        var goalsInBS = await _serviceTGBS.GetByTypicalGoalId(id);

        goal.BonusSchemes = currentBS;
        goal.TypicalGoalsInBonusSchemes = goalsInBS;

       return Ok(goal);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var goal = await _serviceTG.GetAll();

        return Ok(goal);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post(TypicalGoalView goalView)
    {
        if (goalView is null) throw new ArgumentNullException(nameof(goalView));

        var goal = await _serviceTG.Create(goalView);

        return CreatedAtAction(nameof(Get), new { id = goal.Id}, goal);
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TypicalGoalView goalView)
    {
        if (goalView is null) throw new ArgumentNullException(nameof(goalView));

        if (id != goalView.Id) return BadRequest();

        var goal = await _serviceTG.Update(goalView);

        return Ok(goal);
    }
}