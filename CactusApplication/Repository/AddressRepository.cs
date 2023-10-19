using CactusApplication.IRepository;
using CactusDomain.Data;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Address address)
        {
            _context.Add(address);
            return Save();

        }

        public async Task<bool> AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            return await SaveAsync();
        }

        public bool Remove(Address address)
        {
            _context.Addresses.Remove(address);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public bool Update(Address address)
        {
            _context.Addresses.Update(address);
            return Save();

        }

        public async Task<bool> UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            return await SaveAsync();
        }
    }
}
