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
    public class SizeCountRepository : ISizeCountRepository
    {
        private readonly ApplicationDbContext _context;
        public SizeCountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(SizeAndCount sizeAndCount)
        {
            _context.SizeAndCounts.Add(sizeAndCount);
            return Save();
        }

        public async Task<bool> AddAsync(SizeAndCount sizeAndCount)
        {
            await _context.SizeAndCounts.AddAsync(sizeAndCount);
            return await SaveAsync();
        }

        public IEnumerable<SizeAndCount> GetAllByProductId(int productId)
        {
            return _context.SizeAndCounts.Where(s => s.ProductId == productId).ToList();
        }

        public async Task<IEnumerable<SizeAndCount>> GetAllByProductIdAsync(int productId)
        {
            return await _context.SizeAndCounts.Where(s => s.ProductId == productId).ToListAsync();
        }

        public bool Remove(SizeAndCount sizeAndCount)
        {
            _context.SizeAndCounts.Remove(sizeAndCount);
            return Save();
        }

        public Task<bool> RemoveAsync(SizeAndCount sizeAndCount)
        {
            _context.SizeAndCounts.Remove(sizeAndCount);
            return SaveAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool Update(SizeAndCount sizeAndCount)
        {
            _context.SizeAndCounts.Update(sizeAndCount);
            return Save();
        }

        public async Task<bool> UpdateAsync(SizeAndCount sizeAndCount)
        {
            _context.SizeAndCounts.Update(sizeAndCount);
            return await SaveAsync();
        }
    }
}
