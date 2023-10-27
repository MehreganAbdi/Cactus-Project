using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class UserDashBoardController : Controller
    {
        private readonly IUserDashBoardService userDashBoardService;

        public UserDashBoardController(IUserDashBoardService userDashBoardService)
        {
            this.userDashBoardService = userDashBoardService;
        }

        public async Task<IActionResult> Index()
        {
            var userCarts = await userDashBoardService.GetAllByUserIdAsync(User.Identity.GetUserId());

            return View(userCarts);
        }


        public async Task<IActionResult> DeleteItem(int Id)
        {
            await userDashBoardService.RemoveItemAsync(Id);
            return RedirectToAction("Index", "UserDashBoard");
        }



    }
}
