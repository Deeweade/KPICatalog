using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class BonusSchemeLinkMethodsController : ControllerBase
{
    private readonly IBonusSchemeLinkMethodService _service;

    public BonusSchemeLinkMethodsController(IBonusSchemeLinkMethodService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public async Task<List<BonusSchemeLinkMethodView>> GetAll()
    {
        return await _service.GetAll();
    }
}
