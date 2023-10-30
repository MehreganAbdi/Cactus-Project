using CactusDomain.IRepository;
using CactusDomain.Data;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public Address GetAddressById(int Id)
        {
            return _context.Addresses.AsNoTracking().FirstOrDefault(a => a.AddressId == Id);
        }


        public async Task<Address> GetAddressByIdAsync(int Id)
        {
            return await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.AddressId == Id);
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
            var addresss = GetAddressById(address.AddressId);
            addresss.FullAddress = address.FullAddress;
            addresss.PostalCode = address.PostalCode;
            return Save();
        }

        public async Task<bool> UpdateAsync(Address address)
        {
            var addresss = await GetAddressByIdAsync(address.AddressId);
            addresss.FullAddress = address.FullAddress;
            addresss.PostalCode = address.PostalCode;
            return await SaveAsync();
        }
    }
}
