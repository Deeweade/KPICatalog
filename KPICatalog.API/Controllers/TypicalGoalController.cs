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

        return Ok(goal);
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> GetAll()
    {
        var goal = await _serviceTG.GetAll();

        return Ok(goal);
    }

    [HttpGet("getCurrent/{goalId}/{typicalGoalTypeId}")]
    public async Task<IActionResult> GetCurrent(int goalId, int typicalGoalTypeId)
    {
        var goal = await _serviceTG.GetById(goalId);
        var currentBS = await _serviceBS.GetBS(goalId, typicalGoalTypeId);
        var goalsInBS = await _serviceTGBS.GetGoalsInBS();

       return Ok(new TypicalGoalView
        {
            Title = goal.Title,
            PlanningCycleId = goal.PlanningCycleId,
            WeightTypeId = goal.WeightTypeId,
            ParentGoalId = goal.ParentGoalId,
            ExternalId = goal.ExternalId,
            BonusSchemeViews = currentBS,
            TypicalGoalInBonusSchemes = goalsInBS
        });
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