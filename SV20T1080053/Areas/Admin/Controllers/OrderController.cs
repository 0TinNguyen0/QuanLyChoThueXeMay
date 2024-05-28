using Microsoft.AspNetCore.Mvc;
using SV20T1080053.Areas.Admin.Models;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Implementions;
using SV20T1080053.DataLayers.Repositories.Interfaces;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMotorcycleService _motorcycleService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return View(orders);
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
            //try
            //{
            //    // Lấy danh sách xe từ dịch vụ xe
            //    var motorcycles = await _motorcycleService.GetAllMotorcyclesAsync();

            //    // Tạo view model mới và gán danh sách xe vào
            //    var viewModel = new SaveOrderViewModel
            //    {
            //        Motorcycles = motorcycles
            //    };

            //    // Trả về view với view model chứa danh sách xe
             return View(Index);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"Error: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }
    }
}
