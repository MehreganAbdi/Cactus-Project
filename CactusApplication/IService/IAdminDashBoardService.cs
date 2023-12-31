﻿using CactusApplication.DTOs;
using CactusDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.IService
{
    public interface IAdminDashBoardService
    {
        ProductDTO ChangeProductToProductDTO(Product product);
        Task<ProductDTO> ChangeProductToProductDTOAsync(Product product);
        Product ChangeProductDTOToProduct(ProductDTO productDTO);
        Task<Product> ChangeProductDTOToProductAsync(ProductDTO productDTO);

        UserDTO ChangeUserToUserDTO(User user);
        Task<UserDTO> ChangeUserToUserDTOAsync(User user);
        User ChangeUserDTOToUser(UserDTO userDTO);
        Task<User> ChangeUserDTOToUserAsync(UserDTO userDTO);

        CartDTO ChangeUserCartToCartDTO(UserCart userCart);
        Task<CartDTO> ChangeUserCartToCartDTOAsync(UserCart userCart);
        UserCart ChangeCartDTOToUserCart(CartDTO cartDTO);
        Task<UserCart> ChangeCartDTOToUserCartAsync(CartDTO cartDTO);

        IEnumerable<UserDTO> GetAllUsers();
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        IEnumerable<ProductDTO> GetAllProducts();
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        IEnumerable<ProductDTO> GetSoldOutProducts();
        Task<IEnumerable<ProductDTO>> GetSoldOutProductsAsync();
        UserDTO GetUserById(string userId);
        Task<UserDTO> GetUserByIdAsync(string userId);
        IEnumerable<CartDTO> GetAllUserCartsByUserId(string userId);
        Task<IEnumerable<CartDTO>> GetAllUserCartsByUserIdAsync(string userId);
        bool BanUser(string userId);
        Task<bool> BanUserAsync(string userId);
        bool UnBanUser(string userId);
        Task<bool> UnBanUserAsync(string userId);
        bool IsUSerBan(string userId);
        Task<bool> IsUSerBanAsync(string userId);
        bool OffToAll(int percentage);
        Task<bool> OffToAllAsync( int percentage);

    }
}


