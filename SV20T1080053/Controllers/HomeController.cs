using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.Models;
using System.Diagnostics;

namespace SV20T1080053.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMotorcycleService _motorcycleService;
        public HomeController(ILogger<HomeController> logger, IMotorcycleService motorcycleService)
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

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}