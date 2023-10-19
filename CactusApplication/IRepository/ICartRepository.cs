using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IRepository
{
    public interface ICartRepository
    {
        IEnumerable<UserCart> GetAllByUserId(string UserId);
        Task<IEnumerable<UserCart>> GetAllByUserIdAsync(string UserId);
        bool AddToCart(UserCart cart);
        Task<bool> AddToCartAsync(UserCart cart);
        bool Remove(UserCart cart);
        Task<bool> RemoveAsync(UserCart cart);
        bool Save();
        Task<bool> SaveAsync();
    }
}
