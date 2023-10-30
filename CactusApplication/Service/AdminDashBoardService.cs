using CactusApplication.DTOs;
using CactusApplication.IService;
using CactusApplication.Repository;
using CactusDomain.IRepository;
using CactusDomain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.Service
{
    public class AdminDashBoardService : IAdminDashBoardService
    {
        private readonly IAdminDashBoardRepository adminDashBoardRepository;
        private readonly IUserDashBoardRepository userDashBoardRepository;

        public AdminDashBoardService(IAdminDashBoardRepository adminDashBoardRepository,
                                     IUserDashBoardRepository userDashBoardRepository)
        {
            this.adminDashBoardRepository = adminDashBoardRepository;
            this.userDashBoardRepository = userDashBoardRepository;
        }

        public UserCart ChangeCartDTOToUserCart(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId,
                CartItemId = cartDTO.CartItemId
            };
        }

        public async Task<UserCart> ChangeCartDTOToUserCartAsync(CartDTO cartDTO)
        {
            return new UserCart()
            {
                ProductId = cartDTO.ProductId,
                UserId = cartDTO.UserId,
                CartItemId = cartDTO.CartItemId
            };
        }

        public Product ChangeProductDTOToProduct(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductName = productDTO.ProductName,
                AdditionalInfo = productDTO.AdditionalInfo,
                Brand = productDTO.Brand,
                Cost = productDTO.Cost
                ,
                Count = productDTO.Count,
                Size = productDTO.Size
            };
            if (productDTO.ImageUri != null)
            {
                product.Image = productDTO.ImageUri;
            }
            return product;
        }

        public async Task<Product> ChangeProductDTOToProductAsync(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductName = productDTO.ProductName,
                AdditionalInfo = productDTO.AdditionalInfo,
                Brand = productDTO.Brand,
                Cost = productDTO.Cost
                ,
                Count = productDTO.Count,
                Size = productDTO.Size
            };
            if (productDTO.ImageUri != null)
            {
                product.Image = productDTO.ImageUri;
            }
            return product;
        }

        public ProductDTO ChangeProductToProductDTO(Product product)
        {
            return new ProductDTO()
            {
                ProductId = product.ProductId,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Cost,
                ProductName = product.ProductName,
                Count = product.Count,
                Size = product.Size,
                ImageUri = product.Image
            };

        }

        public async Task<ProductDTO> ChangeProductToProductDTOAsync(Product product)
        {
            return new ProductDTO()
            {
                ProductId = product.ProductId,
                AdditionalInfo = product.AdditionalInfo,
                Brand = product.Brand,
                Cost = product.Cost,
                ProductName = product.ProductName,
                Count = product.Count,
                Size = product.Size,
                ImageUri = product.Image
            };
        }

        public CartDTO ChangeUserCartToCartDTO(UserCart userCart)
        {
            var product = adminDashBoardRepository.GetProductById(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO();
            if (product != null)
            {
                productDetailDTO.ProductName = product.ProductName;
                productDetailDTO.AdditionalInfo = product.AdditionalInfo;
                productDetailDTO.Brand = product.Brand;
                productDetailDTO.Cost = product.Cost;
                productDetailDTO.Count = product.Count;
                productDetailDTO.ImageUri = product.Image;
                productDetailDTO.Size = product.Size;
                productDetailDTO.PurchasedCountByUser = userDashBoardRepository.PurchaseCount(userCart.UserId, userCart.ProductId);
                productDetailDTO.IsInFavorites = userDashBoardRepository.IsInFavorites(userCart.UserId, userCart.ProductId);
                productDetailDTO.ProductId = userCart.ProductId;
            }
            return new CartDTO()
            {
                Product = productDetailDTO,
                ProductId = userCart.ProductId,
                UserId = userCart.UserId,
                CartItemId = userCart.CartItemId
            };
        }

        public async Task<CartDTO> ChangeUserCartToCartDTOAsync(UserCart userCart)
        {
            var product = await adminDashBoardRepository.GetProductByIdAsync(userCart.ProductId);
            var productDetailDTO = new ProductDetailDTO();
            if (product != null)
            {
                productDetailDTO.ProductName = product.ProductName;
                productDetailDTO.AdditionalInfo = product.AdditionalInfo;
                productDetailDTO.Brand = product.Brand;
                productDetailDTO.Cost = product.Cost;
                productDetailDTO.Count = product.Count;
                productDetailDTO.ImageUri = product.Image;
                productDetailDTO.Size = product.Size;
                productDetailDTO.PurchasedCountByUser = await userDashBoardRepository.PurchaseCountAsync(userCart.UserId, userCart.ProductId);
                productDetailDTO.IsInFavorites = await userDashBoardRepository.IsInFavoritesAsync(userCart.UserId, userCart.ProductId);
                productDetailDTO.ProductId = userCart.ProductId;
            }
            return new CartDTO()
            {
                Product = productDetailDTO,
                ProductId = userCart.ProductId,
                UserId = userCart.UserId,
                CartItemId = userCart.CartItemId
            };
        }

        public User ChangeUserDTOToUser(UserDTO userDTO)
        {
            return new User()
            {
                Id = userDTO.UserId,
                Address = userDTO.Address,
                AddressId = userDTO.AddressId,
                Email = userDTO.Email,
                TotalCost = userDTO.TotalCost,
                UserName = userDTO.UserName
            };
        }

        public async Task<User> ChangeUserDTOToUserAsync(UserDTO userDTO)
        {
            return new User()
            {
                Id = userDTO.UserId,
                Address = userDTO.Address,
                AddressId = userDTO.AddressId,
                Email = userDTO.Email,
                TotalCost = userDTO.TotalCost,
                UserName = userDTO.UserName
            };
        }

        public UserDTO ChangeUserToUserDTO(User user)
        {
            return new UserDTO()
            {
                UserId = user.Id,
                Address = user.Address,
                AddressId = user.AddressId,
                Email = user.Email,
                TotalCost = user.TotalCost,
                UserName = user.UserName
            };
        }

        public async Task<UserDTO> ChangeUserToUserDTOAsync(User user)
        {
            return new UserDTO()
            {
                UserId = user.Id,
                Address = user.Address,
                AddressId = user.AddressId,
                Email = user.Email,
                TotalCost = user.TotalCost,
                UserName = user.UserName
            };
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var allProductsDTO = new List<ProductDTO>();
            var allProducts = adminDashBoardRepository.GetAllProducts();
            foreach (var product in allProducts)
            {
                allProductsDTO.Add(ChangeProductToProductDTO(product));
            }
            return allProductsDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var allProductsDTO = new List<ProductDTO>();
            var allProducts = await adminDashBoardRepository.GetAllProductsAsync();
            foreach (var product in allProducts)
            {
                allProductsDTO.Add(await ChangeProductToProductDTOAsync(product));
            }
            return allProductsDTO;
        }

        public IEnumerable<CartDTO> GetAllUserCartsByUserId(string userId)
        {
            var allUserCarts = adminDashBoardRepository.GetUserCartsByUserId(userId);
            var allCartDTos = new List<CartDTO>();
            foreach (var cart in allUserCarts)
            {
                allCartDTos.Add(ChangeUserCartToCartDTO(cart));
            }
            return allCartDTos;
        }

        public async Task<IEnumerable<CartDTO>> GetAllUserCartsByUserIdAsync(string userId)
        {
            var allUserCarts = await adminDashBoardRepository.GetUserCartsByUserIdAsync(userId);
            var allCartDTos = new List<CartDTO>();
            foreach (var cart in allUserCarts)
            {
                allCartDTos.Add(await ChangeUserCartToCartDTOAsync(cart));
            }
            return allCartDTos;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = adminDashBoardRepository.GetAllUsers();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(ChangeUserToUserDTO(user));
            }

            return usersDTO;
        }


        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await adminDashBoardRepository.GetAllUsersAsync();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(await ChangeUserToUserDTOAsync(user));
            }

            return usersDTO;
        }

        public IEnumerable<ProductDTO> GetSoldOutProducts()
        {
            var soldOutProducts = adminDashBoardRepository.GetSoldOutProducts();
            var soldOutProductsDTO = new List<ProductDTO>();

            foreach (var product in soldOutProducts)
            {
                soldOutProductsDTO.Add(ChangeProductToProductDTO(product));
            }

            return soldOutProductsDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetSoldOutProductsAsync()
        {
            var soldOutProducts = await adminDashBoardRepository.GetSoldOutProductsAsync();
            var soldOutProductsDTO = new List<ProductDTO>();

            foreach (var product in soldOutProducts)
            {
                soldOutProductsDTO.Add(await ChangeProductToProductDTOAsync(product));
            }

            return soldOutProductsDTO;
        }

        public UserDTO GetUserById(string userId)
        {
            return ChangeUserToUserDTO(adminDashBoardRepository.GetUserByUserId(userId));
        }

        public async Task<UserDTO> GetUserByIdAsync(string userId)
        {
            return await ChangeUserToUserDTOAsync(await adminDashBoardRepository.GetUserByUserIdAsync(userId));
        }
    }
}

