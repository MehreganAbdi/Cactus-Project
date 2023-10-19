using CactusApplication.IRepository;
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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;
        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddToFavorite(UserFavorite favorite)
        {
            _context.UserFavorites.Add(favorite);
            return Save();
        }

        public Task<bool> AddToFavoriteAsync(UserFavorite favorite)
        {
            _context.UserFavorites.AddAsync(favorite);
            return SaveAsync();
        }

        public IEnumerable<UserFavorite> GetAllByUserId(string UserId)
        {
            return _context.UserFavorites.Where(f => f.UserId == UserId).ToList();
        }

        public async Task<IEnumerable<UserFavorite>> GetAllByUserIdAsync(string UserId)
        {
            return await _context.UserFavorites.Where(f => f.UserId == UserId).ToListAsync();
        }

        public bool Remove(UserFavorite favorite)
        {
            _context.UserFavorites.Remove(favorite);
            return Save();
        }

        public async Task<bool> RemoveAsync(UserFavorite favorite)
        {
            _context.UserFavorites.Remove(favorite);
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
