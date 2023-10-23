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
            return await cartRepository.AddToCartAsync(await ChangeToModelAsync(item));
        }

        public CartDTO ChangeToDTO(UserCart userCart)
        {
            var product = cartRepository.GetProductById(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO();

            if (product != null)
            {
                productDetailDTO.AdditionalInfo = product.AdditionalInfo;
                productDetailDTO.Brand = product.Brand;
                productDetailDTO.Cost = product.Count;
                productDetailDTO.Size = product.Size;
                productDetailDTO.Count = product.Count;
                productDetailDTO.ProductId = userCart.ProductId;
                productDetailDTO.ProductName = product.ProductName;
                productDetailDTO.IsInFavorites = cartRepository.IsInFavorite(userCart.UserId, userCart.ProductId);
            }



            return new CartDTO()
            {
                Product = productDetailDTO,
                CartItemId = userCart.CartItemId,
                ProductId = userCart.CartItemId,
                UserId = userCart.UserId
            };

        }

        public async Task<CartDTO> ChangeToDTOAsync(UserCart userCart)
        {
            var product = await cartRepository.GetProductByIdAsync(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO();

            if (product != null)
            {
                productDetailDTO.AdditionalInfo = product.AdditionalInfo;
                productDetailDTO.Brand = product.Brand;
                productDetailDTO.Cost = product.Count;
                productDetailDTO.Size = product.Size;
                productDetailDTO.Count = product.Count;
                productDetailDTO.ProductId = userCart.ProductId;
                productDetailDTO.ProductName = product.ProductName;
                productDetailDTO.IsInFavorites = cartRepository.IsInFavorite(userCart.UserId, userCart.ProductId);
            }



            return new CartDTO()
            {
                Product = productDetailDTO,
                CartItemId = userCart.CartItemId,
                ProductId = userCart.CartItemId,
                UserId = userCart.UserId
            };

        }

        public UserCart ChangeToModel(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId
            };
        }

        public async Task<UserCart> ChangeToModelAsync(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId
            };
        }

        public IEnumerable<CartDTO> GetAllByUserId(string userId)
        {
            var userCart = new List<CartDTO>();
            var items = cartRepository.GetAllByUserId(userId);
            if(items == null)
            {
                return null;
            }
            foreach (var item in items)
            {
                userCart.Add(ChangeToDTO(item));
            }
            return userCart;
        }

        public async Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string userId)
        {
            var userCart = new List<CartDTO>();
            var items = await cartRepository.GetAllByUserIdAsync(userId);
            if (items == null)
            {
                return null;
            }
            foreach (var item in items)
            {
                userCart.Add(await ChangeToDTOAsync(item));
            }
            return userCart;

        }

        public bool RemoveFromCart(CartDTO item)
        {
            return cartRepository.Remove(ChangeToModel(item));
        }

        public async Task<bool> RemoveFromCartAsync(CartDTO item)
        {
            return await cartRepository.RemoveAsync( await ChangeToModelAsync(item));
        }
    }
}
