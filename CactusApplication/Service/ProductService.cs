﻿using CactusApplication.DTOs;
using CactusDomain.IRepository;
using CactusApplication.IService;
using CactusDomain.Models;
using CactusDomain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IFavoriteRepository userFavotireRepository;

        public ProductService(IProductRepository productRepository, IFavoriteRepository userFavotireRepository)
        {
            this.productRepository = productRepository;
            this.userFavotireRepository = userFavotireRepository;
        }

        public bool AddProduct(ProductDTO productDTO)
        {

            productRepository.Add(ChangeToProduct(productDTO));
            return Save();
        }

        public async Task<bool> AddProductAsync(ProductDTO productDTO)
        {
           
            await productRepository.AddAsync(await ChangeToProductAsync(productDTO));
            return await SaveAsync();
        }

        public Product ChangeToProduct(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductName = productDTO.ProductName,
                AdditionalInfo = productDTO.AdditionalInfo,
                Brand = productDTO.Brand,
                Cost = productDTO.Cost,
                Count = productDTO.Count,
                Size = productDTO.Size
            };
            if (productDTO.ImageUri != null)
            {
                product.Image = productDTO.ImageUri;
            }  
               
            return product;
        }

        public async Task<Product> ChangeToProductAsync(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductName = productDTO.ProductName,
                AdditionalInfo = productDTO.AdditionalInfo,
                Brand = productDTO.Brand,
                Cost = productDTO.Cost
                ,
                Count = productDTO.Count,
                Size = productDTO.Size
            };
            if (productDTO.ImageUri != null)
            {
                product.Image = productDTO.ImageUri;
            }
            return  product;
        }

        public ProductDTO ChangeToProductDTO(Product product)
        {
            var productDTO = new ProductDTO()
            {
                ProductId = product.ProductId,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost= product.Cost,
                ProductName= product.ProductName,
                Count = product.Count,
                Size = product.Size
               
            };
            if (product.Image!= null)
            {
                productDTO.ImageUri = product.Image;
            }
            return productDTO;  
        }

        public async Task<ProductDTO> ChangeToProductDTOAsync(Product product)
        {
            var productDTO = new ProductDTO()
            {
                ProductId = product.ProductId,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Cost,
                ProductName = product.ProductName,
                Count = product.Count,
                Size = product.Size
            };
            if (product.Image != null)
            {
                productDTO.ImageUri = product.Image;
            }
            return productDTO;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = productRepository.GetAllProducts();
            var productDTOs = new List<ProductDTO>();
            foreach (var item in products)
            {
                productDTOs.Add(ChangeToProductDTO(item));
            }
            return productDTOs;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllProductsAsync();
            var productDTOs = new List<ProductDTO>();
            foreach (var item in products)
            {
                productDTOs.Add(await ChangeToProductDTOAsync(item));
            }
            return productDTOs;
        }

        public ProductDTO GetProductById(int Id)
        {
            var product = productRepository.GetProductById(Id);
            return ChangeToProductDTO(product);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int Id)
        {
            var product =await productRepository.GetProductByIdAsync(Id);
            return await ChangeToProductDTOAsync(product);

        }

        public async Task<bool> IsInUserFavorites(int productId, string userId)
        {
            var fav = new UserFavorite()
            {
                ProductId = productId,
                UserId = userId
            };
            return await userFavotireRepository.ExistsAsync(fav);
        }

        public int PurchasedCountByUser(int productId, string userId)
        {
            return productRepository.PurchasedCountByUser(productId, userId);
        }

        public async Task<int> PurchasedCountByUserAsync(int productId, string userId)
        {
            return await productRepository.PurchasedCountByUserAsync(productId, userId);
        }

        public bool RemoveProduct(ProductDTO productDTO)
        {
            var product =  productRepository.GetProductById(productDTO.ProductId);

            productRepository.Remove(product);
            return Save();
        }

        public async Task<bool> RemoveProductAsync(ProductDTO productDTO)
        {
            var product = await productRepository.GetProductByIdAsync(productDTO.ProductId);
            await productRepository.RemoveAsync(product);
            return await SaveAsync();
        }

        public bool Save()
        {
            return productRepository.Save();
        }

        public async Task<bool> SaveAsync()
        {
            return await productRepository.SaveAsync();
        }

        public async Task<bool> UpdateProduct(ProductDTO productDTO)
        {
            var porduct = new Product()
            {
                ProductId = productDTO.ProductId,
                AdditionalInfo = productDTO.AdditionalInfo,
                Brand = productDTO.Brand,
                Cost = productDTO.Cost,
                ProductName = productDTO.ProductName,
                Count = productDTO.Count,
                Size = productDTO.Size
            };
            await productRepository.UpdateAsync(porduct);
            return await SaveAsync();
        }
    }
}
