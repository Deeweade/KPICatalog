using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class PlanningCyclesController : ControllerBase
{
    private readonly IPlanningCyclesService _planningCyclesService;

    public PlanningCyclesController(IPlanningCyclesService planningCyclesService)
    {
        _planningCyclesService = planningCyclesService;
    }

    [HttpGet("all")]
    public async Task<List<PlanningCycleView>> GetAll()
    {
        return await _planningCyclesService.GetAll();
    }
}
