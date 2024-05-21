using Microsoft.AspNetCore.Mvc;
using SV20T1080053.Areas.Admin.Models;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DomainModels;
using System.Globalization;
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

        [HttpGet]
        public IActionResult Create()
        {
            var data = new SaveUserViewModel {
                UserId = 0,
            };
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Mục đích của hàm này để nhận dữ liệu từ client về server
        /// giành cho chức năng tạo vào sửa
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save(SaveUserViewModel viewModel)
        {
            // kiểm tra điều kiện
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            // thêm nếu như userId = 0
            if (viewModel.UserId == 0)
            {
                var birthDate = DateTime.ParseExact(viewModel.BirthDate!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var newUser = await _userService.CreateUserAsync(new User
                {
                    FullName = viewModel.FullName!,
                    BirthDate = birthDate,
                    Address = viewModel.Address!,
                    Email = viewModel.Email!,
                    PasswordHash = viewModel.Password!,
                    Phone = viewModel.Phone!,
                    Role = Roles.Customer,
                });

                if (newUser == null) // Nếu email đã tồn tại
                {
                    ModelState.AddModelError("Email", "Email đã có người sử dụng");
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


        //[HttpPost]
        //public async Task<IActionResult> ConfirmDelete(int id)
        //{
        //    try
        //    {
        //        var userToDelete = await _userService.GetUserByIdAsync(id);
        //        if (userToDelete == null)
        //        {
        //            return NotFound();
        //        }

        //        await _userService.DeleteUserAsync(userToDelete);

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

    }
}
