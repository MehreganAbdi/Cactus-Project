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
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext context;

        public AccountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetUserByEmail(string Email)
        {
            return context.Users.FirstOrDefault(u => u.Email == Email);
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == Email);

        }

        public User GetUserById(string UserId)
        {
            return context.Users.FirstOrDefault(u => u.Id== UserId);

        }

        public async Task<User> GetUserByIdAsync(string UserId)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == UserId);

        }
    }
}
