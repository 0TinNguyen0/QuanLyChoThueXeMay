using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.DomainModels;

namespace SV20T1080053.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Login(string email = "", string password = "")
        //{
        //    ViewBag.Email = email;
        //    ViewBag.Password = password;

        //    var user = UserService .Authorize(email, password, TypeOfAccount.User);

        //    if (userAccount != null)
        //    {
        //        // Xác thực thành công, tạo phiên đăng nhập và chuyển hướng
        //        await SignInUser(userAccount);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        // Đăng nhập không thành công, hiển thị thông báo lỗi
        //        ModelState.AddModelError("Error", "Đăng nhập không thành công");
        //        return View();
        //    }
        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User userAccount)
        {
            if (ModelState.IsValid)
            {
                // Gọi phương thức thích hợp từ Business Layer để thêm tài khoản mới vào cơ sở dữ liệu
                // Ví dụ: UserAccountService.Register(userAccount);

                // Sau khi đăng ký thành công, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }
            else
            {
                // Dữ liệu không hợp lệ, hiển thị form đăng ký lại với thông báo lỗi
                return View(userAccount);
            }
        }

        private async Task SignInUser(User user)
        {
            // Tạo đối tượng lưu thông tin phiên đăng nhập của người dùng
            WebUserData userData = new WebUserData()
            {
                UserId = user.UserId.ToString(),
                DisplayName = user.FullName,
                Email = user.Email,
                ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                SessionId = HttpContext.Session.Id,
                AdditionalData = ""
            };

            // Thiết lập phiên đăng nhập
            await HttpContext.SignInAsync(userData.CreatePrincipal());
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
