using CactusApplication.DTOs;
using CactusApplication.IService;
using CactusDomain.IRepository;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Service
{
    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly CactusDomain.IRepository.IFavoriteRepository favoriteRepository;

        public UserFavoriteService(CactusDomain.IRepository.IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }
        public  bool AddToFavorite(UserFavoriteDTO userFavoriteDTO)
        {
            if (!favoriteRepository.Exists(ChangeDTOtoModel(userFavoriteDTO)))
            {
                return favoriteRepository.AddToFavorite(ChangeDTOtoModel(userFavoriteDTO));
            }
            return false;
        }

        public async Task<bool> AddToFavoriteAsync(UserFavoriteDTO userFavoriteDTO)
        {
            if (!await favoriteRepository.ExistsAsync(await ChangeDTOtoModelAsync(userFavoriteDTO)))
            {
                return await favoriteRepository.AddToFavoriteAsync(await ChangeDTOtoModelAsync(userFavoriteDTO));
            }
            return false;
        }

        public UserFavorite ChangeDTOtoModel(UserFavoriteDTO userFavoriteDTO)
        {
            return new UserFavorite() { Id = userFavoriteDTO.Id, ProductId = userFavoriteDTO.ProductId, UserId = userFavoriteDTO.UserId };
        }

        public async Task<UserFavorite> ChangeDTOtoModelAsync(UserFavoriteDTO userFavoriteDTO)
        {
            return new UserFavorite() { Id = userFavoriteDTO.Id, ProductId = userFavoriteDTO.ProductId, UserId = userFavoriteDTO.UserId };
        }


        public UserFavoriteDTO ChangeToDTO(UserFavorite userFavorite)
        {
            return new UserFavoriteDTO() { Id = userFavorite.Id, ProductId = userFavorite.ProductId, UserId = userFavorite.UserId };

        }

        public async Task<UserFavoriteDTO> ChangeToDTOAsync(UserFavorite userFavorite)
        {
            return new UserFavoriteDTO() { Id = userFavorite.Id, ProductId = userFavorite.ProductId, UserId = userFavorite.UserId };

        }


        public IEnumerable<UserFavoriteDTO> GetAllUserFavorites(string UserId)
        {
            var allByUser = favoriteRepository.GetAllByUserId(UserId);
            var allByUserDTO = new List<UserFavoriteDTO>();
            if (allByUser != null)
            {
                foreach (var item in allByUser)
                {
                    allByUserDTO.Add(ChangeToDTO(item));
                }
                return allByUserDTO;
            }
            return null;
        }

        public async Task<IEnumerable<UserFavoriteDTO>> GetAllUserFavoritesAsync(string UserId)
        {
            var allByUser = await favoriteRepository.GetAllByUserIdAsync(UserId);
            var allByUserDTO = new List<UserFavoriteDTO>();
            if (allByUser != null)
            {
                foreach (var item in allByUser)
                {
                    allByUserDTO.Add(await ChangeToDTOAsync(item));
                }
                return allByUserDTO;
            }
            return null;

        }

        public bool RemoveFromFavorites(int ProductId, string UserId)
        {
            return favoriteRepository.Remove(ProductId, UserId);
        }

        public async Task<bool> RemoveFromFavoritesAsync(int ProductId, string UserId)
        {
            return await favoriteRepository.RemoveAsync(ProductId, UserId);

        }
    }
}
