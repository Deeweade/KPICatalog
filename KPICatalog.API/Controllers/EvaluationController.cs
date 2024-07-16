using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Models.Enums;
using KPICatalog.API.Models.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class EvaluationController : ControllerBase
{
    private readonly IEvaluationCalculator _calculator;

    public EvaluationController(IEvaluationCalculator calculator)
    {
        _calculator = calculator;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateEvaluation(CalculateEvaluationView view)
    {
        ArgumentNullException.ThrowIfNull(nameof(view));

        var evaluation = await _calculator.Calculate(view.Plan, view.Fact, (EvaluationMethods)view.EvaluationMethodId, view.RatingScaleId);

        return Ok(evaluation);
    }
}
