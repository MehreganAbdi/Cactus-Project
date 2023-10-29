using CactusApplication.DTOs;
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


        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var userDTO = await userDashBoardService.GetUserDTOByUserIdAsync(User.Identity.GetUserId());
            
            if(userDTO == null)
            {
                return NotFound();
            }
            return View(userDTO);
        
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Fields Must Be Valued";
                return View(userDTO);
            }

            await userDashBoardService.UpdateUserAsync(userDTO);
            return RedirectToAction("Index", "UserDashBoard");
        }

    }
}
