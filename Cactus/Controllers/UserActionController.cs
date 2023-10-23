using CactusApplication.DTOs;
using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class UserActionController : Controller
    {
        private readonly IUserFavoriteService userFavotireService;
        private readonly ICartService cartService;

        public UserActionController(IUserFavoriteService userFavotireService , ICartService cartService)
        {
            this.userFavotireService = userFavotireService;
            this.cartService = cartService;
        }
        public async Task<IActionResult> AddToFavorites(int Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var fav = new UserFavoriteDTO()
            {
                ProductId = Id,
                UserId = User.Identity.GetUserId()
            };
            var x = await userFavotireService.AddToFavoriteAsync(fav);
            if (!x)
            {
                TempData["Error"] = "This Item Is Already In Your Favorites";
            }
            return RedirectToAction("Index", "Product");

        }

        public async Task<IActionResult> RemoveFromFavorites(int Id)
        {
          
            await userFavotireService.RemoveFromFavoritesAsync(Id,User.Identity.GetUserId());
            return RedirectToAction("Index", "Product");
        }


    }
}
