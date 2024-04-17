using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers;

namespace SV20T1080053.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName = "", string password = "")
        {
            ViewBag.Username = userName;
            ViewBag.Password = password;

            var userAccount = UserAccountService.Authorize(userName, password, TypeOfAccount.User);

            // Kiểm tra thông tin đăng nhập đúng hay sai
            //TODO: kiểm tra userName và password từ CSDL

            if (userAccount != null)
            {
                // Đăng nhập thành công.
                //Tạo đối tượng lưu các thông tin của phiên đăng nhập người dùng
                WebUserData userData = new WebUserData()
                {
                    UserId = userAccount.UserId,
                    UserName = userAccount.UserName,
                    DisplayName = userAccount.FullName,
                    Email = userAccount.Email,
                    ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    SessionId = HttpContext.Session.Id,
                    AdditionalData = "",
                    //Roles = new List<string>() { WebUserRoles.Administrator }
                };
                //2.Thiết lập (ghi nhận) phiên đăng nhập
                await HttpContext.SignInAsync(userData.CreatePrincipal());
                //3. Quay lại trang chủ Admin
                //return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Đăng nhập không thành công
                ModelState.AddModelError("Error", "Đăng nhập không thành công");
                return View();
            }

        }
    }
}
