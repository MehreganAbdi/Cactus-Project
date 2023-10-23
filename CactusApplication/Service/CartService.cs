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
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public bool AddToCart(CartDTO item)
        {
            return cartRepository.AddToCart(ChangeToModel(item));
        }

        public async Task<bool> AddToCartAsync(CartDTO item)
        {
            return await cartRepository.AddToCartAsync(await  ChangeToModelAsync(item));
        }

        public CartDTO ChangeToDTO(UserCart userCart)
        {
            var product = cartRepository.GetProductById(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO()
            {
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Count,
                Size = product.Size,
                Count = product.Count,
                ProductId = userCart.ProductId,
                ProductName = product.ProductName,
                IsInFavorites = 
            };
            return new CartDTO()
            {
                Product = 

            };
        }

        public Task<CartDTO> ChangeToDTOAsync(UserCart userCart)
        {
            throw new NotImplementedException();
        }

        public UserCart ChangeToModel(CartDTO cartDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserCart> ChangeToModelAsync(CartDTO cartDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartDTO> GetAllByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromCart(CartDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCartAsync(CartDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
