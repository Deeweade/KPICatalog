using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class WeightTypesController : ControllerBase
{
    private readonly IWeightTypesService _weightTypesService;

    public WeightTypesController(IWeightTypesService weightTypesService)
    {
        _weightTypesService = weightTypesService;
    }

    [HttpGet("all")]
    public async Task<List<WeightTypeView>> GetAll()
    {
        return await _weightTypesService.GetAll();
    }
}
