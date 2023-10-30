using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.IRepository
{
    public interface IAdminDashBoardRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersAsync();
        IEnumerable<UserCart> GetUserCartsByUserId(string userId);
        Task<IEnumerable<UserCart>> GetUserCartsByUserIdAsync(string userId);
        IEnumerable<Product> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        User GetUserByUserId(string userId);
        Task<User> GetUserByUserIdAsync(string userId);
        IEnumerable<Product> GetSoldOutProducts();
        Task<IEnumerable<Product>> GetSoldOutProductsAsync();

    }
}


