﻿using CactusApplication.DTOs;
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

            return View(productDTOs);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            var productDTO = await productService.GetProductByIdAsync(Id);
            if (productDTO != null)
            {
                return View(productDTO);
            }
            TempData["Error"] = "Item Doesn't Exist";

            return RedirectToAction("Index", "Product");
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
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Adding Failed , Try Again";
                return View(productDTO);
            }
            await productService.AddProductAsync(productDTO);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
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
            await productService.UpdateProduct(productDTO);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Delete(int Id)
        {
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
