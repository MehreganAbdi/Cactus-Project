using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class UserActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
