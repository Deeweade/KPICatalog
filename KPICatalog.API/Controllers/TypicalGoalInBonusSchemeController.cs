using KPICatalog.Application.Interfaces.Services;
using KPICatalog.API.Models.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class TypicalGoalInBonusSchemeController : ControllerBase
{
    private readonly ITypicalGoalInBonusSchemeService _service;

    public TypicalGoalInBonusSchemeController(ITypicalGoalInBonusSchemeService service)
    {
        _service = service;
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkCreate(TypicalGoalInBonusSchemeBulkCreateView view)
    {
        if (view is null) throw new ArgumentNullException(nameof(view));

        await _service.BulkCreate(view.BonusSchemesIds, view.TypicalGoals);

        return Ok();
    }
}
