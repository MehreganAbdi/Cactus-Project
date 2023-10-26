using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class UserDashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
