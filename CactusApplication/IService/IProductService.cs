﻿
using CactusApplication.DTOs;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface IProductService
    {
        bool AddProduct(ProductDTO productVM);
        Task<bool> AddProductAsync(ProductDTO productVM);
        bool RemoveProduct(ProductDTO productVM);
        Task<bool> RemoveProductAsync(ProductDTO productVM);
        Task<bool> UpdateProduct(ProductDTO productVM);
        bool Save();
        Task<bool> IsInUserFavorites(int productId, string userId);
        Task<bool> SaveAsync();
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        IEnumerable<ProductDTO> GetAllProducts();
        Product ChangeToProduct(ProductDTO productDTO);
        Task<Product> ChangeToProductAsync(ProductDTO productDTO);
        ProductDTO ChangeToProductDTO(Product product);
        Task<ProductDTO> ChangeToProductDTOAsync(Product product);
        ProductDTO GetProductById(int Id);
        Task<ProductDTO> GetProductByIdAsync(int Id);
        int PurchasedCountByUser(int productId, string userId);
        Task<int> PurchasedCountByUserAsync(int productId, string userId);
    }
}
