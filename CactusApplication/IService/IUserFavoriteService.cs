using CactusApplication.DTOs;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CactusApplication.IService
{
    public interface IUserFavoriteService
    {
        IEnumerable<UserFavoriteDTO> GetAllUserFavorites(string UserId);
        Task<IEnumerable<UserFavoriteDTO>> GetAllUserFavoritesAsync(string UserId);
        bool AddToFavorite(UserFavoriteDTO userFavoriteDTO);
        Task<bool> AddToFavoriteAsync(UserFavoriteDTO userFavoriteDTO);
        bool RemoveFromFavorites(UserFavoriteDTO userFavoriteDTO);
        Task<bool> RemoveFromFavoritesAsync(UserFavoriteDTO userFavoriteDTO);
        UserFavoriteDTO ChangeToDTO(UserFavorite userFavorite);
        Task<UserFavoriteDTO> ChangeToDTOAsync(UserFavorite userFavorite);
        UserFavorite ChangeDTOtoModel(UserFavoriteDTO userFavoriteDTO);
        Task<UserFavorite> ChangeDTOtoModelAsync(UserFavoriteDTO userFavoriteDTO);


    }
}
