using Microsoft.AspNetCore.Mvc;
using SV20T1080053.Areas.Admin.Models;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DomainModels;
using System.Globalization;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandService _brandService;

        public BrandController(ILogger<BrandController> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var brands = await _brandService.GetAllBrandsAsync();
                return View(brands);
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
            var data = new SaveBrandViewModel
            {
                BrandId = 0,
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveBrandViewModel viewModel)
        {
            // kiểm tra điều kiện
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            // thêm nếu như brandId = 0
            if (viewModel.BrandId == 0)
            {
                var newBrand = await _brandService.CreateBrandAsync(new Brand
                {
                    BrandName = viewModel.BrandName!,
                });

                if (newBrand == null) 
                {
                    return View("Create", viewModel);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var brandToDelete = await _brandService.GetBrandByIdAsync(id);
                if (brandToDelete == null)
                {
                    return NotFound(new { success = false, message = "Brand not found" });
                }

                await _brandService.DeleteBrandAsync(brandToDelete);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Internal server error" });
            }
        }
    }
}
