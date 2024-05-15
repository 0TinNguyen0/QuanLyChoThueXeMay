using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUserService _userService;

        public EmployeeController(ILogger<EmployeeController> logger, IUserService userService)
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userToDelete = await _userService.GetUserByIdAsync(id);
                if (userToDelete == null)
                {
                    return NotFound(new { success = false, message = "User not found" });
                }

                await _userService.DeleteUserAsync(userToDelete);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Internal server error" });
            }
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var userToDelete = await _userService.GetUserByIdAsync(id);
                if (userToDelete == null)
                {
                    return NotFound();
                }

                await _userService.DeleteUserAsync(userToDelete);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
