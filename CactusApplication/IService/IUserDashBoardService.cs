using CactusApplication.DTOs;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface IUserDashBoardService
    {
        CartDTO ChangeModelToDTO(UserCart userCart);
        Task<CartDTO> ChangeModelToDTOAsync(UserCart userCart);
        UserCart ChangeDTOtoModel(CartDTO cartDTO);
        Task<UserCart> ChangeDTOtoModelAsync(CartDTO cartDTO);
        bool RemoveItem(int Id);
        Task<bool> RemoveItemAsync(int Id);
        IEnumerable<CartDTO> GetAllByUserId(string userId);
        Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string userId);
        UserDTO GetUserDTOByUserId(string Id);
        Task<UserDTO> GetUserDTOByUserIdAsync(string Id);
        UserDTO ChangeUserToUserDTO(User user);
        Task<UserDTO> ChangeUserToUserDTOAsync(User user);

    }
}
