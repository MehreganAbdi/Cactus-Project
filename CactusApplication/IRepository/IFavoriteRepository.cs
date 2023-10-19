﻿using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IRepository
{
    public  interface IFavoriteRepository
    {
        IEnumerable<UserFavorite> GetAllByUserId(string UserId);
        Task<IEnumerable<UserFavorite>> GetAllByUserIdAsync(string UserId);
        bool AddToFavorite(UserFavorite favorite);
        Task<bool> AddToFavoriteAsync(UserFavorite favorite);
        bool Remove(UserFavorite favorite);
        Task<bool> RemoveAsync(UserFavorite favorite);
        bool Save();
        Task<bool> SaveAsync();
    }
}
