using CactusApplication.DTOs;
using CactusApplication.IRepository;
using CactusDomain.Data;
using CactusDomain.Data.Enums;
using CactusDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Product product)
        {
            var newproduct = new Product()
            {
                ProductName = product.ProductName,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Cost,
                Count = product.Count,
                Size = product.Size
            };
            _context.Products.Add(newproduct);
            return Save();
        }

        public async Task<bool> AddAsync(Product product)
        {
            var newproduct = new Product()
            {
                ProductName = product.ProductName,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Cost,
                Count = product.Count,
                Size = product.Size
            };
            await _context.Products.AddAsync(newproduct);
            return await SaveAsync();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public IEnumerable<Product> GetProductByBrand(Brand brand)
        {
            return _context.Products.Where(p => p.Brand == brand).ToList();
        }

        public async Task<IEnumerable<Product>> GetProductByBrandAsync(Brand brand)
        {
            return await _context.Products.Where(p => p.Brand == brand).ToListAsync();
        }

        public Product GetProductById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == Id);
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == Id);
        }


        public bool Remove(Product product)
        {
            _context.Products.Remove(product);
            return Save();
        }

        public async Task<bool> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            return await SaveAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool Update(Product product)
        {
            _context.Products.Update(product);
            return Save();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            return await SaveAsync();
        }
    }
}
