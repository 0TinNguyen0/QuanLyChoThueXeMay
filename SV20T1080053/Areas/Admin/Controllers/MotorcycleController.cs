using Microsoft.AspNetCore.Mvc;
using SV20T1080053.Areas.Admin.Models;
using SV20T1080053.BusinessLayers.Services.Interfaces;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MotorcycleController : Controller
    {
        private readonly ILogger<MotorcycleController> _logger;
        private readonly IMotorcycleService _motorcycleService;

        public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleService motorcycleService)
        {
            _logger = logger;
            _motorcycleService = motorcycleService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var motorcycles = await _motorcycleService.GetAllMotorcyclesAsync();
                return View(motorcycles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = new SaveUserViewModel
            {
                UserId = 0,
            };
            return View(data);
        }
    }
}
