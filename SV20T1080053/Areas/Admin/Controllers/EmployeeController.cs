using Microsoft.AspNetCore.Mvc;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.Repositories.Interfaces;

namespace SV20T1080053.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserService _userService;

        public EmployeeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUserAsync();
            return View(User);
        }
    }
}
