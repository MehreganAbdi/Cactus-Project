using CactusApplication.DTOs;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface ICartService
    {
        bool AddToCart(CartDTO item);
        Task<bool> AddToCartAsync(CartDTO item);
        bool RemoveFromCart(CartDTO item);
        Task<bool> RemoveFromCartAsync(CartDTO item);
        IEnumerable<CartDTO> GetAllByUserId(string userId);
        Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string  userId);
        CartDTO ChangeToDTO(UserCart userCart);
        Task<CartDTO> ChangeToDTOAsync(UserCart userCart);
        UserCart ChangeToModel(CartDTO cartDTO);
        Task<UserCart> ChangeToModelAsync(CartDTO cartDTO);

    }
}

