using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using KPICatalog.API.Models.Responses;
using KPICatalog.API.Models.Other;
using KPICatalog.API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class TypicalGoalInBonusSchemeController : ControllerBase
{
    private readonly ITypicalGoalInBonusSchemeService _service;
    private readonly IMapper _mapper;
    private readonly ApiClient _apiClient;
    private readonly ApiSettings _apiSettings;

    public TypicalGoalInBonusSchemeController(ITypicalGoalInBonusSchemeService service, ApiClient apiClient,
        IOptions<ApiSettings> apiSettings, IMapper mapper)
    {
        _service = service;
        _apiClient = apiClient;
        _apiSettings = apiSettings.Value;
        _mapper = mapper;
    }

    [HttpPost("calculateEvaluation")]
    public async Task<IActionResult> CalculateEvaluation(Models.Other.CalculateEvaluationView calculateEvaluationView)
    {
        if (calculateEvaluationView is null) throw new ArgumentNullException(nameof(calculateEvaluationView));

        var view = _mapper.Map<Application.Models.Views.CalculateEvaluationView>(calculateEvaluationView);

        var evaluation = await _service.CalculateEvaluation(view);

        return Ok(evaluation);
    }

    [HttpPost("create/bulk")]
    public async Task<IActionResult> BulkCreate(TypicalGoalsInBSBulkCreateView view)
    {
        if (view is null) throw new ArgumentNullException(nameof(view));

        await _service.BulkCreate(view.BonusSchemesIds, view.TypicalGoals);

        return Ok();
    }

    [HttpPost("update/bulk")]
    public async Task<IActionResult> BulkUpdate(TypicalGoalsInBSBulkUpdateView view)
    {
        if (view is null) throw new ArgumentNullException(nameof(view));

        await _service.BulkUpdate(view.EntitiesIds, view.TypicalGoalInBS);

        return Ok();
    }

    [HttpPost("evaluate/bulk")]
    public async Task<IActionResult> BulkEvaluate(List<BulkEvaluateView> evaluateView)
    {
        if (evaluateView is null) throw new ArgumentNullException(nameof(evaluateView));

        var view = _mapper.Map<List<BulkEvaluateGoalsView>>(evaluateView);

        await _service.BulkEvaluate(view);

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
