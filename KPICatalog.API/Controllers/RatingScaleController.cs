using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class RatingScaleController : Controller
    {
        private readonly IRatingScalesService _service;

        public RatingScaleController(IRatingScalesService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public Task<List<RatingScaleView>> GetAll()
        {
            return _service.GetAll();
        }
    }
}
