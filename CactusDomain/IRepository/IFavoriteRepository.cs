using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.IRepository
{
    public  interface IFavoriteRepository
    {
        IEnumerable<UserFavorite> GetAllByUserId(string UserId);
        Task<IEnumerable<UserFavorite>> GetAllByUserIdAsync(string UserId);
        bool AddToFavorite(UserFavorite favorite);
        Task<bool> AddToFavoriteAsync(UserFavorite favorite);
        bool Remove(UserFavorite favorite);
        bool Remove(int ProductId, string UserId);
        Task<bool> RemoveAsync(UserFavorite favorite);
        Task<bool> RemoveAsync(int ProductId, string UserId); 
        Task<bool> ExistsAsync(UserFavorite favorite);
        bool Exists(UserFavorite favorite);
        bool Save();
        Task<bool> SaveAsync();
    }
}
