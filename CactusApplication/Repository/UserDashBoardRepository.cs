using CactusDomain.Data;
using CactusDomain.IRepository;
using CactusDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Repository
{
    public class UserDashBoardRepository : IUserDashBoardRepository
    {

        private readonly ApplicationDbContext context;
        private readonly IAddressRepository addressRepository;

        public UserDashBoardRepository(ApplicationDbContext context , IAddressRepository addressRepository)
        {
            this.context = context;
            this.addressRepository = addressRepository;
        }

        public bool DeleteItemById(int itemId)
        {
            context.UsersCarts.Remove(GetItemById(itemId));
            return Save();
        }

        public async Task<bool> DeleteItemByIdAsync(int itemId)
        {
            context.UsersCarts.Remove(await GetItemByIdAsync(itemId));
            return await SaveAsync();
        }

        public bool DeleteUserById(string userId)
        {
            context.Users.Remove(GetUserById(userId));
            return Save();
        }

        public async Task<bool> DeleteUserByIdAsync(string userId)
        {
            context.Users.Remove(await GetUserByIdAsync(userId));
            return await SaveAsync();
        }

        public IEnumerable<UserCart> GetAll(string userId)
        {
            return context.UsersCarts.Where(t => t.UserId == userId).ToList();
        }

        public async Task<IEnumerable<UserCart>> GetAllAsync(string userId)
        {
            return await context.UsersCarts.Where(t => t.UserId == userId).ToListAsync();
        }


        public UserCart GetItemById(int itemId)
        {
            return context.UsersCarts.FirstOrDefault(i => i.CartItemId == itemId);
        }

        public async Task<UserCart> GetItemByIdAsync(int itemId)
        {
            return await context.UsersCarts.FirstOrDefaultAsync(i => i.CartItemId == itemId);
        }

        public Product GetProductById(int ProductId)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == ProductId);
        }

        public async Task<Product> GetProductByIdAsync(int ProductId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);

        }

        public User GetUserById(string userId)
        {
            return context.Users.Include(u => u.Address).AsNoTracking().FirstOrDefault(u => u.Id == userId);
        }

        public Task<User> GetUserByIdAsync(string userId)
        {
            return context.Users.Include(u => u.Address).AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public bool IsInFavorites(string userId, int ProductId)
        {
            return context.UserFavorites.Any(f => f.UserId == userId && f.ProductId == ProductId);

        }

        public async Task<bool> IsInFavoritesAsync(string userId, int ProductId)
        {
            return await context.UserFavorites.AnyAsync(f => f.UserId == userId && f.ProductId == ProductId);
        }

        public int PurchaseCount(string userId, int ProductId)
        {
            return context.UsersCarts.Count(e => e.UserId == userId && e.ProductId == ProductId);
        }


        public async Task<int> PurchaseCountAsync(string userId, int ProductId)
        {
            return await context.UsersCarts.CountAsync(e => e.UserId == userId && e.ProductId == ProductId);
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool Update(UserCart userCart)
        {
            context.UsersCarts.Update(userCart);
            return Save();
        }

        public Task<bool> UpdateAsync(UserCart userCart)
        {
            context.UsersCarts.Update(userCart);
            return SaveAsync();
        }

        public bool UpdateUser(User user)
        {
            addressRepository.Update(user.Address);
            context.Users.Update(user);
            return Save();
        }
            

        public async Task<bool> UpdateUserAsync(User user)
        {
            await addressRepository.UpdateAsync(user.Address);

            var userr = await GetUserByIdAsync(user.Id);

            userr.Address = user.Address;

            return await SaveAsync();
        }
    }
}
