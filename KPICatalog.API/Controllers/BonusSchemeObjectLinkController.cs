using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class BonusSchemeObjectLinkController : ControllerBase
{
    private readonly IBonusSchemeObjectLinkService _service;

    public BonusSchemeObjectLinkController(IBonusSchemeObjectLinkService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostMany(BonusSchemeObjectLinkView linkView)
    {
        var links = await _service.CreateMany(linkView);

        return Ok(links);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromQuery] List<int> employeeIds, BonusSchemeObjectLinkView linkView)
    {
        if (linkView is null) throw new ArgumentNullException(nameof(linkView));

        var deleteEmployeeIds = await _service.DeleteEmployee(employeeIds, linkView);

        return Ok(deleteEmployeeIds);
    }
}
