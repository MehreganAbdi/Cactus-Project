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
    public class UserDashBoardService : IUserDashBoardService
    {
        private readonly IUserDashBoardRepository userDashBoardRepository;

        public UserDashBoardService(IUserDashBoardRepository userDashBoardRepository)
        {
            this.userDashBoardRepository = userDashBoardRepository;
        }

        public UserCart ChangeDTOtoModel(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId,
                CartItemId = cartDTO.CartItemId
            };
        }

        public async Task<UserCart> ChangeDTOtoModelAsync(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId,
                CartItemId = cartDTO.CartItemId
            };
        }

        public CartDTO ChangeModelToDTO(UserCart userCart)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> ChangeModelToDTOAsync(UserCart userCart)
        {
            var product = await userDashBoardRepository.GetProductByIdAsync(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO();
            if(product!= null)
            {
                productDetailDTO.ProductName = product.ProductName;
                productDetailDTO.AdditionalInfo = product.AdditionalInfo;
                productDetailDTO.Brand = product.Brand;
                productDetailDTO.Cost = product.Cost;
                productDetailDTO.Count = product.Count;
                productDetailDTO.ImageUri = product.Image;
                productDetailDTO.Size = product.Size;

            }
            return new CartDTO()
            {
                Product =  ,

            }
        }

        public IEnumerable<CartDTO> GetAllByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
