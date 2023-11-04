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
    public class AdminDashBoardRepository : IAdminDashBoardRepository
    {
        private readonly ApplicationDbContext context;

        public AdminDashBoardRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool BanUser(User user)
        {
            context.BannedUsers.Add(user);
            return Save();
        }

        public async Task<bool> BanUserAsync(User user)
        {
            await context.BannedUsers.AddAsync(user);
            return await SaveAsync();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }


        public IEnumerable<Product> GetSoldOutProducts()
        {
            return context.Products.Where(p => p.Count < 1).ToList();
        }

        public async Task<IEnumerable<Product>> GetSoldOutProductsAsync()
        {
            return await context.Products.Where(p => p.Count < 1).ToListAsync();
        }


        public User GetUserByUserId(string userId)
        {
            return context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User> GetUserByUserIdAsync(string userId)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public IEnumerable<UserCart> GetUserCartsByUserId(string userId)
        {
            return context.UsersCarts.Where(uc => uc.UserId == userId).ToList();
        }

        public async Task<IEnumerable<UserCart>> GetUserCartsByUserIdAsync(string userId)
        {
            return await context.UsersCarts.Where(uc => uc.UserId == userId).ToListAsync();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool UnBanUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnBanUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
