using CactusApplication.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllProductsAsync();
            if (products == null)
            {
                TempData["Error"] = "No Products Yet!";
            }

            return View();
        }


    }
}
