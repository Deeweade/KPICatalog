using KPICatalog.Application.Interfaces.Services;
using KPICatalog.API.Models.Other;
using KPICatalog.API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using KPICatalog.Application.Models.Views;
using KPICatalog.API.Models.Responses;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class TypicalGoalInBonusSchemeController : ControllerBase
{
    private readonly ITypicalGoalInBonusSchemeService _service;
    private readonly ApiClient _apiClient;
    private readonly ApiSettings _apiSettings;

    public TypicalGoalInBonusSchemeController(ITypicalGoalInBonusSchemeService service, ApiClient apiClient, 
        IOptions<ApiSettings> apiSettings)
    {
        _service = service;
        _apiClient = apiClient;
        _apiSettings = apiSettings.Value;
    }

    [HttpPost("create/bulk")]
    public async Task<IActionResult> BulkCreate(TypicalGoalInBonusSchemeBulkCreateView view)
    {
        if (view is null) throw new ArgumentNullException(nameof(view));

        await _service.BulkCreate(view.BonusSchemesIds, view.TypicalGoals);

        return Ok();
    }

    [HttpPost("update/bulk")]
    public async Task<IActionResult> BulkUpdate(TypicalGoalInBonusSchemeBulkUpdateView view)
    {
        if (view is null) throw new ArgumentNullException(nameof(view));

        await _service.BulkUpdate(view.EntitiesIds, view.TypicalGoalInBS);

        return Ok();
    }

    [HttpPost("sendIntoMyGoals/{bonusSchemeId}")]
    public async Task<IActionResult> SendIntoMyGoals(int bonusSchemeId)
    {
        var goals = await _service.GetGoalsToSync(bonusSchemeId);

        var url = _apiSettings.MyGoalsUrl + "Goals/SyncWithTypicalGoals";

        var response = await _apiClient.PostAsync<GoalsForEmployeesRequestView, GoalsForEmployeesResponseView>(url, goals);

        return Ok(response);
    }
}
