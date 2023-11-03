using CactusApplication.IService;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class AdminDashBoardController : Controller
    {
        private readonly IAdminDashBoardService adminDashBoardService;

        public AdminDashBoardController(IAdminDashBoardService adminDashBoardService)
        {
            this.adminDashBoardService = adminDashBoardService;
        }

        public async Task<IActionResult> Index(string searching)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Product");
            }

            var allProducts = await adminDashBoardService.GetAllProductsAsync();

            if (searching != null)
            {
                allProducts = allProducts.Where(p =>  p.ProductName.Contains(searching) ||
                                                      p.AdditionalInfo.Contains(searching) ||
                                                      p.Brand.ToString().Contains(searching) ||
                                                      p.Size.Contains(searching)).ToList();
            }

            return View(allProducts);
        }

        public async Task<IActionResult> Users()
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Product");
            }

            var allUsers = await adminDashBoardService.GetAllUsersAsync();

            return View(allUsers);
        }


        public async Task<IActionResult> SoldOutProducts()
        {
            if (!User.IsInRole("admin"))
            {
                
                return RedirectToAction("Index", "Product");
            }
            var soldOutProducts = await adminDashBoardService.GetSoldOutProductsAsync();
            return View(soldOutProducts);
        }
    }
}
