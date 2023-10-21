using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.IRepository
{
    public interface IAccountRepository
    {
        User GetUserByEmail(string Email);
        Task<User> GetUserByEmailAsync(string Email);
        User GetUserById(string UserId);
        Task<User> GetUserByIdAsync(string UserId);
        Task<bool> SaveAsync();
    }
}
