using CactusApplication.DTOs;
using CactusApplication.IService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cactus.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserFavoriteService userFavotireService;
        private readonly IPhotoService photoService;

        public ProductController(IProductService productService,
                                 IUserFavoriteService userFavotireService,
                                 IPhotoService photoService)
        {
            this.productService = productService;
            this.userFavotireService = userFavotireService;
            this.photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var productDTOs = await productService.GetAllProductsAsync();
            if (productDTOs == null)
            {
                TempData["Error"] = "No Products Yet!";
            }

            return View(productDTOs);
        }

        public async Task<IActionResult> Detail(int Id)
        {

            var productDTO = await productService.GetProductByIdAsync(Id);

            if (productDTO != null)
            {
                var productDetailDTO = new ProductDetailDTO()
                {
                    AdditionalInfo = productDTO.AdditionalInfo,
                    Size = productDTO.Size,
                    Brand = productDTO.Brand,
                    Cost = productDTO.Cost,
                    Count = productDTO.Count,
                    ProductName = productDTO.ProductName,
                    ProductId = productDTO.ProductId,
                    PurchasedCountByUser = await productService.PurchasedCountByUserAsync(productDTO.ProductId , User.Identity.GetUserId()),
                    ImageUri = productDTO.ImageUri

                };
                if (!User.Identity.IsAuthenticated)
                {
                    productDetailDTO.IsInFavorites= false;
                }
                else
                {

                    productDetailDTO.IsInFavorites = await productService.IsInUserFavorites(Id, User.Identity.GetUserId());
                }
                return View(productDetailDTO);
            }
            TempData["Error"] = "Item Doesn't Exist";

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Product");
            }

            var reloadSafety = new ProductDTO();
            return View(reloadSafety);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Adding Failed , Try Again";
                return View(productDTO);
            }
            var result = await photoService.AddPhotoAsync(productDTO.Image);
            productDTO.ImageUri = result.Uri.ToString();
            await productService.AddProductAsync(productDTO);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Product");
            }
            var productDTO = await productService.GetProductByIdAsync(Id);
            if (productDTO != null)
            {
                return View(productDTO);
            }
            TempData["Error"] = "This Item Doesn't Exist";
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Procccess Failed , Try Again";
                return View(productDTO);
            }

            if (productDTO.Image != null)
            {
                var result = await photoService.AddPhotoAsync(productDTO.Image);
                productDTO.ImageUri = result.Uri.ToString();
            }
            
            await productService.UpdateProduct(productDTO);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Product");
            }
            var product = await productService.GetProductByIdAsync(Id);
            if (product == null)
            {
                TempData["Error"] = "Item Doesn't Exist";
            }
            await productService.RemoveProductAsync(product);

            return RedirectToAction("Index", "Product");

        }



    }
}
