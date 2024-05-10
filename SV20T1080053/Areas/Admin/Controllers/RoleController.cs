using Microsoft.AspNetCore.Mvc;

namespace SV20T1080053.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
