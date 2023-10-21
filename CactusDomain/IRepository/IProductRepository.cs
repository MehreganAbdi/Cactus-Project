using CactusDomain.Data.Enums;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Product GetProductById(int Id);
        Task<Product> GetProductByIdAsync(int Id);
        IEnumerable<Product> GetProductByBrand(Brand brand);
        Task<IEnumerable<Product>> GetProductByBrandAsync(Brand brand);
        bool Add(Product product);
        Task<bool> AddAsync(Product product);
        bool Remove(Product product);
        Task<bool> RemoveAsync(Product product);
        bool Update(Product product);
        Task<bool> UpdateAsync(Product product);
        bool Save();
        Task<bool> SaveAsync();
    }
}
