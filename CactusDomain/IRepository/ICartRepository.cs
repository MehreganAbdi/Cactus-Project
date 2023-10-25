using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.IRepository
{
    public interface ICartRepository
    {
        IEnumerable<UserCart> GetAllByUserId(string UserId);
        Task<IEnumerable<UserCart>> GetAllByUserIdAsync(string UserId);
        bool AddToCart(UserCart cart);
        Task<bool> AddToCartAsync(UserCart cart);
        bool Remove(UserCart cart);
        Task<bool> RemoveAsync(UserCart cart);
        Product GetProductById(int Id);
        Task<Product> GetProductByIdAsync(int Id);
        bool IsInFavorite(string userId, int productId);
        Task<bool> IsInFavoriteAsync(string userId, int productId);
        UserCart GetByItemId(int Id);
        Task<UserCart> GetByItemIdAsync(int Id);

        bool Save();
        Task<bool> SaveAsync();
    }
}
