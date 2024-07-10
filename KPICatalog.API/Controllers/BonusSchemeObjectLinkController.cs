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

    [HttpPost("create/bulk")]
    public async Task<IActionResult> BulkPost(BonusSchemeObjectLinkView linkView)
    {
        var links = await _service.BulkCreate(linkView);

        return Ok(links);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(BonusSchemeObjectLinkView linkView)
    {
        var deletingIds = await _service.Delete(linkView);

        return Ok(deletingIds);
    }
}
