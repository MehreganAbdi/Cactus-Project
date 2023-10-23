using CactusApplication.DTOs;
using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class UserActionController : Controller
    {
        private readonly IUserFavotireService userFavotireService;

        public UserActionController(IUserFavotireService userFavotireService)
        {
            this.userFavotireService = userFavotireService;
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
            await userFavotireService.AddToFavoriteAsync(fav);

            return RedirectToAction("Index", "Product");

        }

    }
}
