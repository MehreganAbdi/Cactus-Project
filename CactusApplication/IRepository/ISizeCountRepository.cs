using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IRepository
{
    public interface ISizeCountRepository
    {
        IEnumerable<SizeAndCount> GetAllByProductId(int productId);
        Task<IEnumerable<SizeAndCount>> GetAllByProductIdAsync(int productId);
        bool Add(SizeAndCount sizeAndCount);
        Task<bool> AddAsync(SizeAndCount sizeAndCount);
        bool Remove(SizeAndCount sizeAndCount);
        Task<bool> RemoveAsync(SizeAndCount sizeAndCount);
        bool Update(SizeAndCount sizeAndCount);
        Task<bool> UpdateAsync(SizeAndCount sizeAndCount);
        bool Save();
        Task<bool> SaveAsync();
    }
}
