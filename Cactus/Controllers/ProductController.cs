using CactusApplication.DTOs;
using CactusApplication.IService;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var productDTOs = await productService.GetAllProductsAsync();
            if (productDTOs == null)
            {
                TempData["Error"] = "No Products Yet!";
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var reloadSafety = new ProductDTO();
            return View(reloadSafety);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            var addingResult = await productService.AddProductAsync(productDTO);
            if (!addingResult)
            {
                TempData["Error"] = "Adding Failed , Try Again";
                return View(productDTO);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var productDTO = await productService.GetProductByIdAsync(Id);
            if (productDTO!= null)
            {
                return View(productDTO);
            }
            TempData["Error"] = "This Item Doesn't Exist";
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            var result = await productService.UpdateProduct(productDTO);
            if (result)
            {
                return RedirectToAction("Index","Product");
            }
            TempData["Error"] = "Procccess Failed , Try Again";
            return View(productDTO);
        }
        
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await productService.RemoveProductAsync(await productService.GetProductByIdAsync(Id));
            if (result)
            {
                return RedirectToAction("Index", "Product");
            }
            TempData["Error"] = "Item Doesn't Exist , Try Again";
            return RedirectToAction("Index", "Product");
        }



    }
}
