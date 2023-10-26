using CactusDomain.Models;

namespace CactusDomain.IRepository
{
    public interface IUserDashBoard
    {
        IEnumerable<UserCart> GetAll(string userId);
        Task<IEnumerable<UserCart>> GetAllAsync(string userId);
        Task<UserCart> GetByIdAsync(string userId);
        UserCart GetById(string userId);
        bool Save();
        Task<bool> SaveAsync();
        Task<bool> DeleteByIdAsync(string userId);
        bool DeleteById(string userId);
        bool Update(UserCart userCart);
        Task<bool> UpdateAsync(UserCart userCart);
    }
}
