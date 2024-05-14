using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SV20T1080053.DomainModels;
using SV20T1080053.Models;

namespace SV20T1080053.Areas.Admin.Controllers
{
   //[Authorize(Roles = $"{WebUserRoles.Employee}")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {

                return View();

        }
    }
}
