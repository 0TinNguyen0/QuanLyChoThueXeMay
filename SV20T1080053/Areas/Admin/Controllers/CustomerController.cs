using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DomainModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IUserService _userService;

        public CustomerController(ILogger<CustomerController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Thêm khách hàng vào cơ sở dữ liệu
                    user.Role = Roles.Customer; // Đảm bảo vai trò là khách hàng
                    await _userService.CreateUserAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Error creating customer. Please try again."); // Thêm thông báo lỗi vào ModelState
                    return View(user);
                }
            }
            return View(user);
        }   

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }


    }
}
