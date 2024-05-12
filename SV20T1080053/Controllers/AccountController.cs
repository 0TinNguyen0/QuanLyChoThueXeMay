using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DomainModels;

namespace SV20T1080053.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email = "", string password = "")
        {
            var user = await _userService.GetUserByEmailAndPasswordAsync(email, password);

            if (user != null)
            {
                // Kiểm tra vai trò của người dùng
                if (user.Role == Roles.Employee)
                {
                    // Đăng nhập thành công cho Employee.
                    //Tạo đối tượng lưu các thông tin của phiên đăng nhập người dùng
                    WebUserData userData = new WebUserData()
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Photo = user.Photo,
                        ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                        SessionId = HttpContext.Session.Id,
                        AdditionalData = "",
                        Roles = new List<string>() { Roles.Employee.ToString() }
                    };
                    // Thiết lập (ghi nhận) phiên đăng nhập
                    await HttpContext.SignInAsync(userData.CreatePrincipal(), new AuthenticationProperties
                    {
                        IsPersistent = true, // Lưu phiên đăng nhập sau khi đóng trình duyệt
                        ExpiresUtc = System.DateTime.UtcNow.AddMinutes(20) // Thời gian hết hạn của phiên là 20 phút
                    });
                    // Chuyển hướng đến trang Admin
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (user.Role == Roles.Customer)
                {
                    // Đăng nhập thành công cho Customer.
                    //Tạo đối tượng lưu các thông tin của phiên đăng nhập người dùng
                    WebUserData userData = new WebUserData()
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Photo = user.Photo,
                        ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                        SessionId = HttpContext.Session.Id,
                        AdditionalData = "",
                        Roles = new List<string>() { Roles.Customer.ToString() }
                    };
                    // Thiết lập (ghi nhận) phiên đăng nhập
                    await HttpContext.SignInAsync(userData.CreatePrincipal(), new AuthenticationProperties
                    {
                        IsPersistent = true, // Lưu phiên đăng nhập sau khi đóng trình duyệt
                        ExpiresUtc = System.DateTime.UtcNow.AddMinutes(20) // Thời gian hết hạn của phiên là 20 phút
                    });
                    // Chuyển hướng đến trang Home
                    return RedirectToAction("Index", "Home");
                }
            }
            // Đăng nhập không thành công
            ModelState.AddModelError("Error", "Đăng nhập không thành công");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
