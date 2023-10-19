﻿using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IRepository
{
    public interface IAddressRepository
    {
        bool Add(Address address);
        Task<bool> AddAsync(Address address);
        bool Remove(Address address);
        bool Update(Address address);
        Task<bool> UpdateAsync(Address address);
        bool Save();
        Task<bool> SaveAsync();

    }
}
