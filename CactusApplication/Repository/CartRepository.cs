using CactusDomain.IRepository;
using CactusDomain.Data;
using CactusDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddToCart(UserCart cart)
        {
            _context.UsersCarts.Add(cart);
            return Save();
        }

        public async Task<bool> AddToCartAsync(UserCart cart)
        {
            await _context.UsersCarts.AddAsync(cart);
            return await SaveAsync();
        }

        public IEnumerable<UserCart> GetAllByUserId(string UserId)
        {
            return _context.UsersCarts.Where(c => c.UserId == UserId).ToList();
        }

        public async Task<IEnumerable<UserCart>> GetAllByUserIdAsync(string UserId)
        {
            return await _context.UsersCarts.Where(c => c.UserId == UserId).ToListAsync();
        }

        public bool Remove(UserCart cart)
        {
            _context.UsersCarts.Remove(cart);
            return Save();
        }

        public async Task<bool> RemoveAsync(UserCart cart)
        {
            _context.UsersCarts.Remove(cart);
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
    }
}
