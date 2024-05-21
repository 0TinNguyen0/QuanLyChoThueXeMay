using Microsoft.AspNetCore.Mvc;
using SV20T1080053.Areas.Admin.Models;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Interfaces;
using SV20T1080053.DomainModels;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MotorcycleController : Controller
    {
        private readonly ILogger<MotorcycleController> _logger;
        private readonly IMotorcycleService _motorcycleService;
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandService _brandService;

        public MotorcycleController(ILogger<MotorcycleController> logger, IMotorcycleService motorcycleService, IBrandRepository brandRepository, IBrandService brandService)
        {
            _logger = logger;
            _motorcycleService = motorcycleService;
            _brandRepository = brandRepository;
            _brandService = brandService;
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
        public async Task<IActionResult> Create()
        {
            var brands = await _brandRepository.GetAllAsync();
            var data = new SaveMotorcycleViewModel
            {
                MotorcycleId = 0,
                Brands = brands
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveMotorcycleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllBrandsAsync();
                model.Brands = brands;
                return View("Create", model);
            }

            try
            {
                // Map SaveMotorcycleViewModel to Motorcycle domain model
                var motorcycle = new Motorcycle
                {
                    MotorcycleId = model.MotorcycleId,
                    MotorcycleName = model.MotocycleName,
                    BrandId = model.BrandId,
                    ReleaseYear = DateTime.Parse(model.ReleaseYear),
                    Type = model.Type.Value,
                    Color = model.Color,
                    Amount = decimal.Parse(model.Amount),
                    Status = model.StatusName.Value,
                    Description = model.Description,
                    Photo = model.Photo
                };

                // Save or update motorcycle
                if (model.MotorcycleId == 0)
                {
                    await _motorcycleService.CreateMotorcycleAsync(motorcycle);
                }
                else
                {
                    await _motorcycleService.UpdateMotorcycleAsync(motorcycle);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
