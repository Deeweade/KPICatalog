using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class EvaluationMethodsController : ControllerBase
{
    private readonly IEvaluationMethodsService _evaluationMethodsService;

    public EvaluationMethodsController(IEvaluationMethodsService evaluationMethodsService)
    {
        _evaluationMethodsService = evaluationMethodsService;
    }

    [HttpGet("all")]
    public async Task<List<EvaluationMethodView>> GetAll()
    {
        return await _evaluationMethodsService.GetAll();
    }
}
