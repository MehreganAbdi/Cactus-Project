using CactusApplication.DTOs;
using CactusApplication.IService;
using CactusDomain.IRepository;
using CactusDomain.Models;
using Microsoft.AspNet.Identity;


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
            var product = userDashBoardRepository.GetProductById(userCart.ProductId);
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
                productDetailDTO.PurchasedCountByUser = await userDashBoardRepository.PurchaseCountAsync(userCart.UserId , userCart.ProductId);
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

        public User ChangeUserDTOToUser(UserDTO user)
        {
            return new User()
            {
                Id = user.UserId,
                Address = user.Address,
                AddressId = user.AddressId,
                Email = user.Email,
                TotalCost = user.TotalCost,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<User> ChangeUserDTOToUserAsync(UserDTO user)
        {
            return new User()
            {
                Id = user.UserId,
                Address = user.Address,
                AddressId = user.AddressId,
                Email = user.Email,
                TotalCost = user.TotalCost,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
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
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
         }

        public async Task<UserDTO> ChangeUserToUserDTOAsync(User user)
        {
            return new UserDTO()
            {
                UserId = user.Id,
                Address = new Address()
                {
                    AddressId = user.AddressId,
                    FullAddress = user.Address.FullAddress,
                    PostalCode = user.Address.PostalCode
                },
                AddressId = user.AddressId,
                Email = user.Email,
                TotalCost = user.TotalCost,
                UserName = user.UserName,
                FullAddress = user.Address.FullAddress,
                Postal = user.Address.PostalCode,
                PhoneNumber = user.PhoneNumber
            };
        }

        public IEnumerable<CartDTO> GetAllByUserId(string userId)
        {
            var all = userDashBoardRepository.GetAll(userId);
            var allToDTO = new List<CartDTO>();
            if(all!= null)
            {
                foreach (var item in all)
                {
                    allToDTO.Add( ChangeModelToDTO(item));
                }
            }
            return allToDTO;
        }

        public async Task<IEnumerable<CartDTO>> GetAllByUserIdAsync(string userId)
        {
            var all = await userDashBoardRepository.GetAllAsync(userId);
            var allToDTO = new List<CartDTO>();
            if (all != null)
            {
                foreach (var item in all)
                {
                    allToDTO.Add(await ChangeModelToDTOAsync(item));
                }
            }
            return allToDTO;

        }

        public UserDTO GetUserDTOByUserId(string Id)
        {
            return ChangeUserToUserDTO(userDashBoardRepository.GetUserById(Id));
        }

        public async Task<UserDTO> GetUserDTOByUserIdAsync(string Id)
        {
            return await ChangeUserToUserDTOAsync(await userDashBoardRepository.GetUserByIdAsync(Id));
        }

        public bool RemoveItem(int Id)
        {
            return userDashBoardRepository.DeleteItemById(Id);
        }

        public async Task<bool> RemoveItemAsync(int Id)
        {
            return await userDashBoardRepository.DeleteItemByIdAsync(Id);
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            return userDashBoardRepository.UpdateUser(ChangeUserDTOToUser(userDTO));
        }

        public async Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            return await userDashBoardRepository.UpdateUserAsync(await ChangeUserDTOToUserAsync(userDTO));
        }
    }
}
