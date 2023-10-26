﻿using CactusDomain.Models;

namespace CactusDomain.IRepository
{
    public interface IUserDashBoardRepository
    {
        IEnumerable<UserCart> GetAll(string userId);
        Task<IEnumerable<UserCart>> GetAllAsync(string userId);
        Task<User> GetUserByIdAsync(string userId);
        User GetUserById(string userId);
        Task<UserCart> GetItemByIdAsync(int itemId);
        UserCart GetItemById(int itemId);

        bool Save();
        Task<bool> SaveAsync();
        Task<bool> DeleteItemByIdAsync(int itemId);
        bool DeleteItemById(int itemId);
        Task<bool> DeleteUserByIdAsync(string userId);
        bool DeleteUserById(string userId);
        bool Update(UserCart userCart);
        Task<bool> UpdateAsync(UserCart userCart);
    }
}
