using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cactus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminDashBoardService adminDashBoardService;

        public HomeController(ILogger<HomeController> logger , 
                                IAdminDashBoardService adminDashBoardService)
        {
            _logger = logger;
            this.adminDashBoardService = adminDashBoardService;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated && await adminDashBoardService.IsUSerBanAsync(User.Identity.GetUserId()))
            {
                TempData["Error"] = "You Are Banned";
            }
            return View();
        }

    }
}